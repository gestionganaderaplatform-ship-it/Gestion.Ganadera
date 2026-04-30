using FluentValidation;
using FluentValidation.Results;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Messages;
using Gestion.Ganadera.Business.Domain.Features.Ganaderia;
using Microsoft.EntityFrameworkCore;

namespace Gestion.Ganadera.Business.Infrastructure.Persistence.Repositories.Ganaderia.Procesos;

public class CompraRepository(AppDbContext context) : ICompraRepository
{
    private const string TipoIdentificadorInternoSistema = "INTERNO_SISTEMA";

    public async Task<bool> CrearRegistroAtomicoAsync(
        Animal animal,
        IdentificadorAnimal identificador,
        EventoGanadero evento,
        EventoGanaderoAnimal eventoAnimal,
        EventoDetalleCompra fotoRegistro,
        CancellationToken cancellationToken = default)
    {
        return await RegistrarLoteAtomicoAsync(
            [(animal, identificador, evento, eventoAnimal, fotoRegistro)],
            cancellationToken);
    }

    public async Task<bool> RegistrarLoteAtomicoAsync(
        IEnumerable<(Animal Animal, IdentificadorAnimal Identificador, EventoGanadero Evento, EventoGanaderoAnimal EventoAnimal, EventoDetalleCompra Foto)> lote,
        CancellationToken cancellationToken = default)
    {
        var strategy = context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var tipoIdentificadorInternoCache = new Dictionary<long, long>();

                foreach (var item in lote)
                {
                    await context.Animales.AddAsync(item.Animal, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);

                    if (!tipoIdentificadorInternoCache.TryGetValue(item.Animal.Finca_Codigo, out var tipoIdentificadorInternoCodigo))
                    {
                        tipoIdentificadorInternoCodigo = await ObtenerTipoIdentificadorInternoCodigoAsync(
                            item.Animal.Finca_Codigo,
                            cancellationToken);
                        tipoIdentificadorInternoCache[item.Animal.Finca_Codigo] = tipoIdentificadorInternoCodigo;
                    }

                    var identificadorInterno = new IdentificadorAnimal
                    {
                        Animal_Codigo = item.Animal.Animal_Codigo,
                        Tipo_Identificador_Codigo = tipoIdentificadorInternoCodigo,
                        Identificador_Animal_Valor = ConstruirIdentificadorInterno(item.Animal.Animal_Codigo),
                        Identificador_Animal_Es_Principal = false,
                        Identificador_Animal_Activo = true
                    };

                    item.Identificador.Animal_Codigo = item.Animal.Animal_Codigo;
                    await context.IdentificadoresAnimal.AddRangeAsync(
                        [item.Identificador, identificadorInterno],
                        cancellationToken);

                    await context.EventosGanaderos.AddAsync(item.Evento, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);

                    item.EventoAnimal.Evento_Ganadero_Codigo = item.Evento.Evento_Ganadero_Codigo;
                    item.EventoAnimal.Animal_Codigo = item.Animal.Animal_Codigo;
                    await context.EventosGanaderosAnimal.AddAsync(item.EventoAnimal, cancellationToken);

                    item.Foto.Evento_Ganadero_Codigo = item.Evento.Evento_Ganadero_Codigo;
                    await context.EventosDetalleCompra.AddAsync(item.Foto, cancellationToken);
                }

                await context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }

    public async Task<int> ObtenerSiguienteConsecutivoAsync(long fincaCodigo, CancellationToken cancellationToken = default)
    {
        var totalAnimales = await context.Animales
            .AsNoTracking()
            .CountAsync(item => item.Finca_Codigo == fincaCodigo, cancellationToken);

        return totalAnimales + 1;
    }

    private async Task<long> ObtenerTipoIdentificadorInternoCodigoAsync(
        long fincaCodigo,
        CancellationToken cancellationToken)
    {
        var clienteCodigo = await context.Fincas
            .Where(f => f.Finca_Codigo == fincaCodigo)
            .Select(f => f.Cliente_Codigo)
            .FirstOrDefaultAsync(cancellationToken);

        var tipoIdentificadorInternoCodigo = await context.TiposIdentificador
            .IgnoreQueryFilters()
            .Where(item =>
                item.Cliente_Codigo == clienteCodigo &&
                item.Tipo_Identificador_Codigo_Interno == TipoIdentificadorInternoSistema &&
                item.Tipo_Identificador_Activo)
            .Select(item => (long?)item.Tipo_Identificador_Codigo)
            .FirstOrDefaultAsync(cancellationToken);

        if (!tipoIdentificadorInternoCodigo.HasValue)
        {
            throw new ValidationException(
            [
                new ValidationFailure(
                    nameof(IdentificadorAnimal.Tipo_Identificador_Codigo),
                    CompraMessages.TipoIdentificadorInternoNoDisponible)
            ]);
        }

        return tipoIdentificadorInternoCodigo.Value;
    }

    private static string ConstruirIdentificadorInterno(long animalCodigo)
        => $"INT-{animalCodigo:D10}";
}
