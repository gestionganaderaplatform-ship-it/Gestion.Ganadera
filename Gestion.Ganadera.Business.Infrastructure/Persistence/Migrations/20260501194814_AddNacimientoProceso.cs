using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion.Ganadera.Business.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNacimientoProceso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal_Relacion_Familiar",
                schema: "Ganaderia",
                columns: table => new
                {
                    Animal_Relacion_Familiar_Codigo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Animal_Codigo_Madre = table.Column<long>(type: "bigint", nullable: false),
                    Animal_Codigo_Cria = table.Column<long>(type: "bigint", nullable: false),
                    Animal_Relacion_Familiar_Tipo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Animal_Relacion_Familiar_Fecha_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Animal_Relacion_Familiar_Activa = table.Column<bool>(type: "bit", nullable: false),
                    Cliente_Codigo = table.Column<long>(type: "bigint", nullable: true),
                    Fecha_Creado = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    Fecha_Modificado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creado_Por = table.Column<long>(type: "bigint", nullable: false),
                    Modificado_Por = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal_Relacion_Familiar", x => x.Animal_Relacion_Familiar_Codigo);
                    table.ForeignKey(
                        name: "FK_Animal_Relacion_Familiar_Animal_Animal_Codigo_Cria",
                        column: x => x.Animal_Codigo_Cria,
                        principalSchema: "Ganaderia",
                        principalTable: "Animal",
                        principalColumn: "Animal_Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Relacion_Familiar_Animal_Animal_Codigo_Madre",
                        column: x => x.Animal_Codigo_Madre,
                        principalSchema: "Ganaderia",
                        principalTable: "Animal",
                        principalColumn: "Animal_Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evento_Detalle_Nacimiento",
                schema: "Ganaderia",
                columns: table => new
                {
                    Evento_Ganadero_Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Animal_Codigo_Madre = table.Column<long>(type: "bigint", nullable: false),
                    Animal_Codigo_Cria = table.Column<long>(type: "bigint", nullable: false),
                    Tipo_Identificador_Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Evento_Detalle_Nacimiento_Identificador_Valor = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Categoria_Animal_Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Potrero_Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Evento_Detalle_Nacimiento_Sexo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Evento_Detalle_Nacimiento_Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Evento_Detalle_Nacimiento_Peso_Nacer = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Evento_Detalle_Nacimiento_Observacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cliente_Codigo = table.Column<long>(type: "bigint", nullable: true),
                    Fecha_Creado = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    Fecha_Modificado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creado_Por = table.Column<long>(type: "bigint", nullable: false),
                    Modificado_Por = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento_Detalle_Nacimiento", x => x.Evento_Ganadero_Codigo);
                    table.ForeignKey(
                        name: "FK_Evento_Detalle_Nacimiento_Animal_Animal_Codigo_Cria",
                        column: x => x.Animal_Codigo_Cria,
                        principalSchema: "Ganaderia",
                        principalTable: "Animal",
                        principalColumn: "Animal_Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Detalle_Nacimiento_Animal_Animal_Codigo_Madre",
                        column: x => x.Animal_Codigo_Madre,
                        principalSchema: "Ganaderia",
                        principalTable: "Animal",
                        principalColumn: "Animal_Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Detalle_Nacimiento_Categoria_Animal_Categoria_Animal_Codigo",
                        column: x => x.Categoria_Animal_Codigo,
                        principalSchema: "Ganaderia",
                        principalTable: "Categoria_Animal",
                        principalColumn: "Categoria_Animal_Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Detalle_Nacimiento_Evento_Ganadero_Evento_Ganadero_Codigo",
                        column: x => x.Evento_Ganadero_Codigo,
                        principalSchema: "Ganaderia",
                        principalTable: "Evento_Ganadero",
                        principalColumn: "Evento_Ganadero_Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Detalle_Nacimiento_Potrero_Potrero_Codigo",
                        column: x => x.Potrero_Codigo,
                        principalSchema: "Ganaderia",
                        principalTable: "Potrero",
                        principalColumn: "Potrero_Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evento_Detalle_Nacimiento_Tipo_Identificador_Tipo_Identificador_Codigo",
                        column: x => x.Tipo_Identificador_Codigo,
                        principalSchema: "Ganaderia",
                        principalTable: "Tipo_Identificador",
                        principalColumn: "Tipo_Identificador_Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Relacion_Familiar_Animal_Codigo_Cria",
                schema: "Ganaderia",
                table: "Animal_Relacion_Familiar",
                column: "Animal_Codigo_Cria");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Relacion_Familiar_Animal_Codigo_Madre_Animal_Relacion_Familiar_Activa",
                schema: "Ganaderia",
                table: "Animal_Relacion_Familiar",
                columns: new[] { "Animal_Codigo_Madre", "Animal_Relacion_Familiar_Activa" });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_Relacion_Familiar_Cliente_Codigo_Animal_Codigo_Madre_Animal_Codigo_Cria",
                schema: "Ganaderia",
                table: "Animal_Relacion_Familiar",
                columns: new[] { "Cliente_Codigo", "Animal_Codigo_Madre", "Animal_Codigo_Cria" },
                unique: true,
                filter: "[Cliente_Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Detalle_Nacimiento_Animal_Codigo_Cria",
                schema: "Ganaderia",
                table: "Evento_Detalle_Nacimiento",
                column: "Animal_Codigo_Cria");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Detalle_Nacimiento_Animal_Codigo_Madre",
                schema: "Ganaderia",
                table: "Evento_Detalle_Nacimiento",
                column: "Animal_Codigo_Madre");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Detalle_Nacimiento_Categoria_Animal_Codigo",
                schema: "Ganaderia",
                table: "Evento_Detalle_Nacimiento",
                column: "Categoria_Animal_Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Detalle_Nacimiento_Potrero_Codigo",
                schema: "Ganaderia",
                table: "Evento_Detalle_Nacimiento",
                column: "Potrero_Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_Detalle_Nacimiento_Tipo_Identificador_Codigo",
                schema: "Ganaderia",
                table: "Evento_Detalle_Nacimiento",
                column: "Tipo_Identificador_Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal_Relacion_Familiar",
                schema: "Ganaderia");

            migrationBuilder.DropTable(
                name: "Evento_Detalle_Nacimiento",
                schema: "Ganaderia");
        }
    }
}
