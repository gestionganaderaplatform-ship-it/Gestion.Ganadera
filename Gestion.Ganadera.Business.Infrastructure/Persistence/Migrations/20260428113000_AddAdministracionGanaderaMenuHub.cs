using Gestion.Ganadera.Business.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.Ganadera.Business.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(AppDbContext))]
    [Migration("20260428113000_AddAdministracionGanaderaMenuHub")]
    public partial class AddAdministracionGanaderaMenuHub : Migration
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
                WHERE Menu_Navegacion_Clave IN (N'administracion', N'administracion-ganadera', N'configuracion-fincas', N'configuracion-marcas-ganaderas')
                ORDER BY
                    CASE Menu_Navegacion_Clave
                        WHEN N'administracion' THEN 0
                        WHEN N'administracion-ganadera' THEN 1
                        WHEN N'configuracion-fincas' THEN 2
                        ELSE 3
                    END,
                    Menu_Navegacion_Codigo;

                IF @AdministracionCodigo IS NULL
                BEGIN
                    INSERT INTO Aplicacion.Menu_Navegacion
                    (
                        Menu_Navegacion_Padre_Codigo,
                        Menu_Navegacion_Clave,
                        Menu_Navegacion_Titulo,
                        Menu_Navegacion_Icono,
                        Menu_Navegacion_Tipo,
                        Menu_Navegacion_Ruta,
                        Menu_Navegacion_Accion,
                        Menu_Navegacion_Orden,
                        Menu_Navegacion_Esta_Activo,
                        Menu_Navegacion_Requiere_Cuenta_Padre,
                        Menu_Navegacion_Permiso_Requerido
                    )
                    VALUES
                    (
                        NULL,
                        N'administracion',
                        N'Administración',
                        N'domain',
                        N'route',
                        N'/administracion',
                        NULL,
                        35,
                        1,
                        1,
                        NULL
                    );

                    SET @AdministracionCodigo = SCOPE_IDENTITY();
                END
                ELSE
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
                WHERE Menu_Navegacion_Clave IN (N'administracion-ganadera', N'configuracion-fincas', N'configuracion-marcas-ganaderas')
                  AND Menu_Navegacion_Codigo <> @AdministracionCodigo;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                DELETE FROM Aplicacion.Menu_Navegacion
                WHERE Menu_Navegacion_Clave = N'administracion';
                """);
        }
    }
}
