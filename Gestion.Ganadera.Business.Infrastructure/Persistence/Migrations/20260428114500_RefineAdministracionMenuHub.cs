using Gestion.Ganadera.Business.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.Ganadera.Business.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(AppDbContext))]
    [Migration("20260428114500_RefineAdministracionMenuHub")]
    public partial class RefineAdministracionMenuHub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                DECLARE @AdministracionCodigo bigint;

                SELECT TOP (1)
                    @AdministracionCodigo = Menu_Navegacion_Codigo
                FROM Aplicacion.Menu_Navegacion
                WHERE Menu_Navegacion_Clave IN (N'administracion', N'administracion-ganadera')
                ORDER BY
                    CASE Menu_Navegacion_Clave
                        WHEN N'administracion' THEN 0
                        ELSE 1
                    END,
                    Menu_Navegacion_Codigo;

                IF @AdministracionCodigo IS NOT NULL
                BEGIN
                    UPDATE Aplicacion.Menu_Navegacion
                    SET
                        Menu_Navegacion_Padre_Codigo = NULL,
                        Menu_Navegacion_Clave = N'administracion',
                        Menu_Navegacion_Titulo = N'Administración',
                        Menu_Navegacion_Icono = N'domain',
                        Menu_Navegacion_Tipo = N'route',
                        Menu_Navegacion_Ruta = N'/administracion',
                        Menu_Navegacion_Accion = NULL,
                        Menu_Navegacion_Orden = 35,
                        Menu_Navegacion_Esta_Activo = 1,
                        Menu_Navegacion_Requiere_Cuenta_Padre = 1,
                        Menu_Navegacion_Permiso_Requerido = NULL
                    WHERE Menu_Navegacion_Codigo = @AdministracionCodigo;
                END;

                DELETE FROM Aplicacion.Menu_Navegacion
                WHERE Menu_Navegacion_Clave = N'administracion-ganadera';
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                DECLARE @AdministracionCodigo bigint =
                (
                    SELECT TOP (1) Menu_Navegacion_Codigo
                    FROM Aplicacion.Menu_Navegacion
                    WHERE Menu_Navegacion_Clave = N'administracion'
                );

                IF @AdministracionCodigo IS NOT NULL
                BEGIN
                    UPDATE Aplicacion.Menu_Navegacion
                    SET
                        Menu_Navegacion_Clave = N'administracion-ganadera',
                        Menu_Navegacion_Titulo = N'Administración ganadera',
                        Menu_Navegacion_Ruta = N'/administracion/fincas',
                        Menu_Navegacion_Requiere_Cuenta_Padre = 0
                    WHERE Menu_Navegacion_Codigo = @AdministracionCodigo;
                END;
                """);
        }
    }
}
