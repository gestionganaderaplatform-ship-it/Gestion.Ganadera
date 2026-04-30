using FluentValidation;
using Gestion.Ganadera.Business.Application.Common.Constants;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.CategoriasAnimales.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Fincas.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Potreros.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Messages;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Models;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.RegistroExistente.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.RangosEdades.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.TiposIdentificadores.Interfaces;

namespace Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Validators;

public class RegistrarCompraValidator : AbstractValidator<RegistrarCompraRequest>
{
    public RegistrarCompraValidator(IValidator<ValidarCompraRequest> validadorBase)
    {
        Include(validadorBase);

        RuleFor(x => x.Fecha_Compra)
            .NotEmpty().WithMessage(CompraMessages.FechaCompraRequerida)
            .Must(fecha => fecha.Date <= DateTime.Today).WithMessage(CompraMessages.FechaCompraFutura);

        RuleFor(x => x.Origen_Vendedor)
            .NotEmpty().WithMessage(CompraMessages.OrigenVendedorRequerido);
    }
}

public class RegistrarCompraLoteValidator : AbstractValidator<RegistrarCompraLoteRequest>
{
    public RegistrarCompraLoteValidator(
        IValidarRegistroExistenteRepository registroExistenteRepository,
        IFincaRepository fincaRepository,
        IPotreroRepository potreroRepository,
        ICategoriaAnimalRepository categoriaRepository,
        IRangoEdadRepository rangoRepository,
        ITipoIdentificadorRepository tipoIdentificadorRepository)
    {
        RuleFor(x => x.Finca_Codigo)
            .GreaterThan(0).WithMessage(CompraMessages.FincaCodigoInvalido)
            .MustAsync(async (codigo, _) => await fincaRepository.Existe(codigo))
            .WithMessage(CompraMessages.FincaNoExiste);

        RuleFor(x => x.Fecha_Compra)
            .NotEmpty().WithMessage(CompraMessages.FechaCompraRequerida)
            .Must(fecha => fecha.Date <= DateTime.Today).WithMessage(CompraMessages.FechaCompraFutura);

        RuleFor(x => x.Origen_Vendedor)
            .NotEmpty().WithMessage(CompraMessages.OrigenVendedorRequerido);

        RuleFor(x => x.Valor_Total)
            .Must(valor => !valor.HasValue || valor.Value > 0)
            .WithMessage(CompraMessages.ValorTotalInvalido);

        RuleFor(x => x.Animales)
            .NotEmpty().WithMessage(CompraMessages.LoteSinAnimales)
            .Must(animales => animales is null || animales.Count <= 100).WithMessage(CompraMessages.LoteSuperaMaximo)
            .Must(NoHayIdentificadoresRepetidos).WithMessage(CompraMessages.IdentificadoresRepetidosEnLote);

        When(x => x.Finca_Codigo > 0 && x.Animales is { Count: > 0 }, () =>
        {
            RuleFor(x => x)
                .MustAsync(async (request, cancellationToken) =>
                    await TodosLosPotrerosPertenecenAFincaAsync(
                        request,
                        registroExistenteRepository,
                        cancellationToken))
                .WithMessage(CompraMessages.PotreroNoPerteneceAFinca)
                .WithName(nameof(RegistrarCompraLoteRequest.Animales));

            RuleFor(x => x)
                .MustAsync(async (request, cancellationToken) =>
                    await NoHayIdentificadoresActivosEnFincaAsync(
                        request,
                        registroExistenteRepository,
                        cancellationToken))
                .WithMessage(CompraMessages.IdentificadorDuplicado)
                .WithName(nameof(RegistrarCompraLoteRequest.Animales));
        });

        When(x => x.Valor_Total.HasValue && x.Animales.Any(animal => animal.Valor_Individual.HasValue), () =>
        {
            RuleFor(x => x)
                .Must(TodosLosAnimalesTienenValorIndividual)
                .WithMessage(CompraMessages.ValoresIndividualesIncompletos)
                .WithName(nameof(RegistrarCompraLoteRequest.Animales));

            RuleFor(x => x)
                .Must(ValorTotalCoincideConDetalle)
                .WithMessage(CompraMessages.ValorTotalNoCoincide)
                .WithName(nameof(RegistrarCompraLoteRequest.Valor_Total));
        });

        RuleForEach(x => x.Animales)
            .SetValidator(new CompraAnimalValidator(
                potreroRepository,
                categoriaRepository,
                rangoRepository,
                tipoIdentificadorRepository));
    }

    private static bool NoHayIdentificadoresRepetidos(IEnumerable<CompraAnimalRequest>? animales)
    {
        if (animales is null)
        {
            return true;
        }

        var identificadores = animales
            .Select(animal => animal?.Identificador_Principal?.Trim() ?? string.Empty)
            .Where(identificador => !string.IsNullOrWhiteSpace(identificador))
            .ToList();

        return identificadores.Count == identificadores.Distinct(StringComparer.OrdinalIgnoreCase).Count();
    }

    private static async Task<bool> TodosLosPotrerosPertenecenAFincaAsync(
        RegistrarCompraLoteRequest request,
        IValidarRegistroExistenteRepository registroExistenteRepository,
        CancellationToken cancellationToken)
    {
        var potreros = request.Animales
            .Select(animal => animal.Potrero_Codigo)
            .Where(codigo => codigo > 0)
            .Distinct()
            .ToList();

        foreach (var potreroCodigo in potreros)
        {
            if (!await registroExistenteRepository.FincaPoseePotreroAsync(
                    request.Finca_Codigo,
                    potreroCodigo,
                    cancellationToken))
            {
                return false;
            }
        }

        return true;
    }

    private static bool TodosLosAnimalesTienenValorIndividual(RegistrarCompraLoteRequest request)
    {
        return request.Animales.All(animal => animal.Valor_Individual.HasValue);
    }

    private static async Task<bool> NoHayIdentificadoresActivosEnFincaAsync(
        RegistrarCompraLoteRequest request,
        IValidarRegistroExistenteRepository registroExistenteRepository,
        CancellationToken cancellationToken)
    {
        var identificadores = request.Animales
            .Select(animal => animal?.Identificador_Principal?.Trim() ?? string.Empty)
            .Where(identificador => !string.IsNullOrWhiteSpace(identificador))
            .Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var identificador in identificadores)
        {
            if (await registroExistenteRepository.ExisteIdentificadorActivoEnFincaAsync(
                    request.Finca_Codigo,
                    identificador,
                    cancellationToken))
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValorTotalCoincideConDetalle(RegistrarCompraLoteRequest request)
    {
        var sumaDetalle = request.Animales
            .Where(animal => animal.Valor_Individual.HasValue)
            .Sum(animal => animal.Valor_Individual!.Value);

        return Math.Abs(sumaDetalle - request.Valor_Total!.Value) <= 0.01m;
    }
}

public class CompraAnimalValidator : AbstractValidator<CompraAnimalRequest>
{
    public CompraAnimalValidator(
        IPotreroRepository potreroRepository,
        ICategoriaAnimalRepository categoriaRepository,
        IRangoEdadRepository rangoRepository,
        ITipoIdentificadorRepository tipoIdentificadorRepository)
    {
        RuleFor(x => x.Identificador_Principal)
            .NotEmpty().WithMessage(CompraMessages.IdentificadorRequerido)
            .Matches(RegexPatterns.AlfanumericoConAcentosYPuntuacion).WithMessage(CompraMessages.IdentificadorFormatoInvalido);

        RuleFor(x => x.Potrero_Codigo)
            .GreaterThan(0).WithMessage(CompraMessages.PotreroCodigoInvalido)
            .MustAsync(async (codigo, _) => await potreroRepository.Existe(codigo))
            .WithMessage(CompraMessages.PotreroNoExiste);

        RuleFor(x => x.Categoria_Animal_Codigo)
           .GreaterThan(0).WithMessage(CompraMessages.CategoriaCodigoInvalido)
           .MustAsync(async (codigo, _) => await categoriaRepository.Existe(codigo))
           .WithMessage(CompraMessages.CategoriaNoExiste);

        When(
            x => x.Categoria_Animal_Codigo > 0 &&
                 !string.IsNullOrWhiteSpace(x.Animal_Sexo),
            () =>
            {
                RuleFor(x => x)
                    .MustAsync(async (request, cancellationToken) =>
                        await categoriaRepository.EsCompatibleConSexoAsync(
                            request.Categoria_Animal_Codigo,
                            request.Animal_Sexo,
                            cancellationToken))
                    .WithMessage(CompraMessages.CategoriaIncompatibleConSexo)
                    .WithName(nameof(CompraAnimalRequest.Categoria_Animal_Codigo));
            });

        RuleFor(x => x.Rango_Edad_Codigo)
           .GreaterThan(0).WithMessage(CompraMessages.RangoEdadCodigoInvalido)
           .MustAsync(async (codigo, _) => await rangoRepository.Existe(codigo))
           .WithMessage(CompraMessages.RangoNoExiste);

        RuleFor(x => x.Tipo_Identificador_Codigo)
           .GreaterThan(0).WithMessage(CompraMessages.TipoIdentificadorCodigoInvalido)
           .MustAsync(async (codigo, _) => await tipoIdentificadorRepository.Existe(codigo))
           .WithMessage(CompraMessages.TipoIdentificadorNoExiste);

        RuleFor(x => x.Animal_Sexo)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage(CompraMessages.SexoRequerido)
           .Must(EsSexoValido)
           .WithMessage(CompraMessages.SexoInvalido);

        RuleFor(x => x.Valor_Individual)
            .Must(valor => !valor.HasValue || valor.Value > 0)
            .WithMessage(CompraMessages.ValorIndividualInvalido);
    }

    private static bool EsSexoValido(string? sexo)
    {
        return sexo?.Trim().ToUpperInvariant() switch
        {
            "M" => true,
            "H" => true,
            "MACHO" => true,
            "HEMBRA" => true,
            _ => false
        };
    }
}
