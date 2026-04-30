using Gestion.Ganadera.Business.Application.Abstractions.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Interfaces;
using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Models;
using Gestion.Ganadera.Business.Domain.Features.Ganaderia;

namespace Gestion.Ganadera.Business.Infrastructure.Services.Ganaderia.Procesos;

public class CompraService(
    ICompraRepository repository,
    ICurrentActorProvider currentActorProvider) : ICompraService
{
    public Task<bool> CrearRegistroAsync(
        RegistrarCompraRequest request,
        CancellationToken cancellationToken = default)
    {
        var entidades = CrearEntidades(
            request.Finca_Codigo,
            request.Potrero_Codigo,
            request.Categoria_Animal_Codigo,
            request.Rango_Edad_Codigo,
            request.Tipo_Identificador_Codigo,
            request.Identificador_Principal,
            request.Animal_Sexo,
            request.Fecha_Compra,
            request.Origen_Vendedor,
            request.Valor_Individual,
            request.Observacion);

        return repository.CrearRegistroAtomicoAsync(
            entidades.Animal,
            entidades.Identificador,
            entidades.Evento,
            entidades.EventoAnimal,
            entidades.Foto,
            cancellationToken);
    }

    public Task<bool> RegistrarLoteAsync(
        RegistrarCompraLoteRequest request,
        CancellationToken cancellationToken = default)
    {
        var valorIndividualPromedio = CalcularValorIndividual(request.Valor_Total, request.Animales.Count);

        var lote = request.Animales
            .Select(animal => CrearEntidades(
                request.Finca_Codigo,
                animal.Potrero_Codigo,
                animal.Categoria_Animal_Codigo,
                animal.Rango_Edad_Codigo,
                animal.Tipo_Identificador_Codigo,
                animal.Identificador_Principal,
                animal.Animal_Sexo,
                request.Fecha_Compra,
                request.Origen_Vendedor,
                animal.Valor_Individual ?? valorIndividualPromedio,
                request.Observacion))
            .ToList();

        return repository.RegistrarLoteAtomicoAsync(lote, cancellationToken);
    }

    public Task<int> ObtenerSiguienteConsecutivoAsync(
        long fincaCodigo,
        CancellationToken cancellationToken = default)
    {
        return repository.ObtenerSiguienteConsecutivoAsync(fincaCodigo, cancellationToken);
    }

    private (Animal Animal, IdentificadorAnimal Identificador, EventoGanadero Evento, EventoGanaderoAnimal EventoAnimal, EventoDetalleCompra Foto) CrearEntidades(
        long fincaCodigo,
        long potreroCodigo,
        long categoriaAnimalCodigo,
        long rangoEdadCodigo,
        long tipoIdentificadorCodigo,
        string identificadorPrincipal,
        string animalSexo,
        DateTime fechaCompra,
        string origenVendedor,
        decimal? valorIndividual,
        string? observacion)
    {
        var usuarioLogueado = currentActorProvider.ActorEmail ?? currentActorProvider.ActorId ?? "SISTEMA";
        var fechaOperacion = DateTime.Now;
        var identificadorNormalizado = identificadorPrincipal.Trim();

        var animal = new Animal
        {
            Finca_Codigo = fincaCodigo,
            Potrero_Codigo = potreroCodigo,
            Categoria_Animal_Codigo = categoriaAnimalCodigo,
            Animal_Sexo = animalSexo,
            Animal_Origen_Ingreso = AnimalOrigenIngreso.Compra,
            Animal_Activo = true,
            Animal_Fecha_Ingreso_Inicial = fechaCompra,
            Animal_Fecha_Registro_Ingreso = fechaOperacion,
            Animal_Fecha_Ultimo_Evento = fechaCompra
        };

        var identificador = new IdentificadorAnimal
        {
            Tipo_Identificador_Codigo = tipoIdentificadorCodigo,
            Identificador_Animal_Valor = identificadorNormalizado,
            Identificador_Animal_Es_Principal = true,
            Identificador_Animal_Activo = true
        };

        var evento = new EventoGanadero
        {
            Finca_Codigo = fincaCodigo,
            Evento_Ganadero_Tipo = EventoGanaderoTipo.Compra,
            Evento_Ganadero_Fecha = fechaCompra,
            Evento_Ganadero_Fecha_Registro = fechaOperacion,
            Evento_Ganadero_Registrado_Por = usuarioLogueado,
            Evento_Ganadero_Estado = EventoGanaderoEstado.Completado,
            Evento_Ganadero_Observacion = observacion,
            Evento_Ganadero_Es_Correccion = false,
            Evento_Ganadero_Es_Anulacion = false
        };

        var eventoAnimal = new EventoGanaderoAnimal
        {
            Evento_Ganadero_Animal_Estado_Afectacion = EventoGanaderoAnimalEstadoAfectacion.Procesado
        };

        var fotoRegistro = new EventoDetalleCompra
        {
            Potrero_Codigo = potreroCodigo,
            Categoria_Animal_Codigo = categoriaAnimalCodigo,
            Rango_Edad_Codigo = rangoEdadCodigo,
            Tipo_Identificador_Codigo = tipoIdentificadorCodigo,
            Evento_Detalle_Compra_Identificador_Valor = identificadorNormalizado,
            Evento_Detalle_Compra_Sexo = animalSexo,
            Evento_Detalle_Compra_Fecha_Compra = fechaCompra,
            Evento_Detalle_Compra_Origen_Vendedor = origenVendedor.Trim(),
            Evento_Detalle_Compra_Valor_Individual = valorIndividual,
            Evento_Detalle_Compra_Observacion = observacion
        };

        return (animal, identificador, evento, eventoAnimal, fotoRegistro);
    }

    private static decimal? CalcularValorIndividual(decimal? valorTotal, int cantidadAnimales)
    {
        if (!valorTotal.HasValue || cantidadAnimales <= 0)
        {
            return null;
        }

        return Math.Round(valorTotal.Value / cantidadAnimales, 2, MidpointRounding.AwayFromZero);
    }
}
