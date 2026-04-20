using Gestion.Ganadera.Application.Features.Ganaderia.Procesos.RegistroExistente.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestion.Ganadera.Infrastructure.Persistence.Repositories.Ganaderia.Procesos;

public class ValidarRegistroExistenteRepository(AppDbContext context) : IValidarRegistroExistenteRepository
{
    public async Task<bool> ExisteIdentificadorActivoEnClienteAsync(
        string identificadorPrincipal, 
        long tipoIdentificadorCodigo, 
        CancellationToken cancellationToken = default)
    {
        return await context.IdentificadoresAnimal.AsNoTracking()
            .AnyAsync(x => x.Identificador_Animal_Valor == identificadorPrincipal 
                        && x.Tipo_Identificador_Codigo == tipoIdentificadorCodigo
                        && x.Identificador_Animal_Activo, cancellationToken);
    }

    public async Task<bool> FincaPoseePotreroAsync(
        long fincaCodigo, 
        long potreroCodigo, 
        CancellationToken cancellationToken = default)
    {
        return await context.Potreros.AsNoTracking()
            .AnyAsync(x => x.Finca_Codigo == fincaCodigo 
                        && x.Potrero_Codigo == potreroCodigo, cancellationToken);
    }
}
