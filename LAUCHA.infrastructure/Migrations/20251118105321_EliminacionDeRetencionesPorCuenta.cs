using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionDeRetencionesPorCuenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialRetencionesFijas");

            migrationBuilder.DropTable(
                name: "RetencionesFijasPorCuentas");

            migrationBuilder.DropTable(
                name: "RetencionesFijas");

            migrationBuilder.RenameColumn(
                name: "estadoCuenta",
                table: "Cuentas",
                newName: "EstadoCuenta");

            migrationBuilder.CreateTable(
                name: "RetencionAcuerdo",
                columns: table => new
                {
                    CodigoRetencion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoAcuerdo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrimeraQuincena = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AcuerdoCodigo = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionAcuerdo", x => new { x.CodigoRetencion, x.CodigoAcuerdo });
                    table.ForeignKey(
                        name: "FK_RetencionAcuerdo_Acuerdos_AcuerdoCodigo",
                        column: x => x.AcuerdoCodigo,
                        principalTable: "Acuerdos",
                        principalColumn: "Codigo");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionCatalogo",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrimeraQuincena = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionCatalogo", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "RetencionCatalogo",
                columns: new[] { "Codigo", "Concepto", "EsPorcentual", "PrimeraQuincena", "Unidades" },
                values: new object[,]
                {
                    { "0900", "Jubilacion", true, false, 11m },
                    { "0905", "Ley 19032", true, false, 3m },
                    { "0910", "Obra Social", true, false, 3m },
                    { "0920", "Aporte Sindical Obligatorio", true, false, 2.5m },
                    { "0940", "Seguro y Sepelio", false, true, 2300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetencionAcuerdo_AcuerdoCodigo",
                table: "RetencionAcuerdo",
                column: "AcuerdoCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetencionAcuerdo");

            migrationBuilder.DropTable(
                name: "RetencionCatalogo");

            migrationBuilder.RenameColumn(
                name: "EstadoCuenta",
                table: "Cuentas",
                newName: "estadoCuenta");

            migrationBuilder.CreateTable(
                name: "RetencionesFijas",
                columns: table => new
                {
                    CodigoRetencionFija = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsQuincenal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionesFijas", x => x.CodigoRetencionFija);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialRetencionesFijas",
                columns: table => new
                {
                    CodigoRetencionFija = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaFinVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialRetencionesFijas", x => new { x.CodigoRetencionFija, x.FechaFinVigencia });
                    table.ForeignKey(
                        name: "FK_HistorialRetencionesFijas_RetencionesFijas_CodigoRetencionFi~",
                        column: x => x.CodigoRetencionFija,
                        principalTable: "RetencionesFijas",
                        principalColumn: "CodigoRetencionFija",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionesFijasPorCuentas",
                columns: table => new
                {
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoRetencionFija = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionesFijasPorCuentas", x => new { x.NumeroCuenta, x.CodigoRetencionFija });
                    table.ForeignKey(
                        name: "FK_RetencionesFijasPorCuentas_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetencionesFijasPorCuentas_RetencionesFijas_CodigoRetencionF~",
                        column: x => x.CodigoRetencionFija,
                        principalTable: "RetencionesFijas",
                        principalColumn: "CodigoRetencionFija",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "RetencionesFijas",
                columns: new[] { "CodigoRetencionFija", "Concepto", "EsPorcentual", "EsQuincenal", "Unidades" },
                values: new object[,]
                {
                    { "0900", "Jubilacion", true, false, 11m },
                    { "0905", "Ley 19032", true, false, 3m },
                    { "0910", "Obra Social", true, false, 3m },
                    { "0920", "Aporte Sindical Obligatorio", true, false, 2.5m },
                    { "0940", "Seguro y Sepelio", false, true, 2300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetencionesFijasPorCuentas_CodigoRetencionFija",
                table: "RetencionesFijasPorCuentas",
                column: "CodigoRetencionFija");
        }
    }
}
