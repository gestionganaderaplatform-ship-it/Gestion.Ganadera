using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.Ganadera.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Aplicacion");

            migrationBuilder.CreateTable(
                name: "Menu_Navegacion",
                schema: "Aplicacion",
                columns: table => new
                {
                    Menu_Navegacion_Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Navegacion_Padre_Codigo = table.Column<long>(type: "bigint", nullable: true),
                    Menu_Navegacion_Clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Menu_Navegacion_Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Menu_Navegacion_Icono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Menu_Navegacion_Tipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Menu_Navegacion_Ruta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Menu_Navegacion_Accion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Menu_Navegacion_Orden = table.Column<int>(type: "int", nullable: false),
                    Menu_Navegacion_Esta_Activo = table.Column<bool>(type: "bit", nullable: false),
                    Menu_Navegacion_Requiere_Cuenta_Padre = table.Column<bool>(type: "bit", nullable: false),
                    Menu_Navegacion_Permiso_Requerido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Navegacion", x => x.Menu_Navegacion_Codigo);
                    table.ForeignKey(
                        name: "FK_Menu_Navegacion_Menu_Navegacion_Menu_Navegacion_Padre_Codigo",
                        column: x => x.Menu_Navegacion_Padre_Codigo,
                        principalSchema: "Aplicacion",
                        principalTable: "Menu_Navegacion",
                        principalColumn: "Menu_Navegacion_Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Navegacion_Menu_Navegacion_Clave",
                schema: "Aplicacion",
                table: "Menu_Navegacion",
                column: "Menu_Navegacion_Clave",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Navegacion_Menu_Navegacion_Padre_Codigo_Menu_Navegacion_Orden",
                schema: "Aplicacion",
                table: "Menu_Navegacion",
                columns: new[] { "Menu_Navegacion_Padre_Codigo", "Menu_Navegacion_Orden" });

            migrationBuilder.InsertData(
                schema: "Aplicacion",
                table: "Menu_Navegacion",
                columns: new[]
                {
                    "Menu_Navegacion_Codigo",
                    "Menu_Navegacion_Accion",
                    "Menu_Navegacion_Clave",
                    "Menu_Navegacion_Esta_Activo",
                    "Menu_Navegacion_Icono",
                    "Menu_Navegacion_Orden",
                    "Menu_Navegacion_Padre_Codigo",
                    "Menu_Navegacion_Permiso_Requerido",
                    "Menu_Navegacion_Requiere_Cuenta_Padre",
                    "Menu_Navegacion_Ruta",
                    "Menu_Navegacion_Tipo",
                    "Menu_Navegacion_Titulo"
                },
                values: new object[,]
                {
                    { 1L, null, "inicio", true, "pi pi-home", 10, null, null, false, "/inicio", "route", "Inicio" },
                    { 2L, null, "seguridad", true, "pi pi-shield", 20, null, null, false, "/seguridad", "group", "Seguridad" },
                    { 3L, null, "configuracion", true, "pi pi-cog", 30, null, null, false, "/configuracion", "group", "Configuracion" },
                    { 4L, "logout", "cerrar-sesion", true, "pi pi-sign-out", 40, null, null, false, null, "action", "Cerrar sesion" },
                    { 5L, null, "seguridad-auditoria", true, "pi pi-history", 10, 2L, null, false, "/seguridad/auditoria", "route", "Auditoria" },
                    { 6L, null, "seguridad-sesiones", true, "pi pi-desktop", 20, 2L, null, false, "/seguridad/sesiones", "route", "Sesiones" },
                    { 7L, null, "seguridad-accesos", true, "pi pi-key", 30, 2L, null, false, "/seguridad/accesos", "route", "Accesos" },
                    { 8L, null, "configuracion-preferencias", true, "pi pi-sliders-h", 10, 3L, null, false, "/configuracion/preferencias", "route", "Preferencias" },
                    { 9L, null, "configuracion-cuenta", true, "pi pi-user", 20, 3L, null, false, "/configuracion/cuenta", "route", "Cuenta" },
                    { 10L, null, "configuracion-delegados", true, "pi pi-users", 30, 3L, null, true, "/configuracion/delegados", "route", "Delegados" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu_Navegacion",
                schema: "Aplicacion");
        }
    }
}
