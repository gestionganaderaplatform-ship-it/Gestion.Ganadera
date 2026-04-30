using Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Models;

namespace Gestion.Ganadera.Business.Application.Features.Ganaderia.Procesos.Compra.Interfaces;

public interface ICompraService
{
    Task<bool> CrearRegistroAsync(RegistrarCompraRequest request, CancellationToken cancellationToken = default);
    Task<bool> RegistrarLoteAsync(RegistrarCompraLoteRequest request, CancellationToken cancellationToken = default);
    Task<int> ObtenerSiguienteConsecutivoAsync(long fincaCodigo, CancellationToken cancellationToken = default);
}
