using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregoPagosYEliminoRemuneraciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liquidaciones_LiquidacionesGenerales_CodigoLiquidacionGeneral",
                table: "Liquidaciones");

            migrationBuilder.DropTable(
                name: "LiquidacionesGenerales");

            migrationBuilder.DropTable(
                name: "PagosLiquidaciones");

            migrationBuilder.DropTable(
                name: "RemuneracionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "Remuneraciones");

            migrationBuilder.DropIndex(
                name: "IX_Liquidaciones_CodigoLiquidacionGeneral",
                table: "Liquidaciones");


            migrationBuilder.DropColumn(
                name: "CodigoLiquidacionGeneral",
                table: "Liquidaciones");

            migrationBuilder.DropColumn(
                name: "FechaLiquidacion",
                table: "Liquidaciones");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LiquidacionId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Liquidaciones_LiquidacionId",
                        column: x => x.LiquidacionId,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_LiquidacionId",
                table: "Pagos",
                column: "LiquidacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.AddColumn<string>(
                name: "CodigoLiquidacionGeneral",
                table: "Liquidaciones",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLiquidacion",
                table: "Liquidaciones",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LiquidacionesGenerales",
                columns: table => new
                {
                    CodigoLiquidacionGeneral = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinPeriodo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InicioPeriodo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalDescuentos = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalRemuneracion = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalRetencion = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidacionesGenerales", x => x.CodigoLiquidacionGeneral);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagosLiquidaciones",
                columns: table => new
                {
                    CodigoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosLiquidaciones", x => x.CodigoPago);
                    table.ForeignKey(
                        name: "FK_PagosLiquidaciones_Liquidaciones_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Remuneraciones",
                columns: table => new
                {
                    CodigoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsBlanco = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remuneraciones", x => x.CodigoRemuneracion);
                    table.ForeignKey(
                        name: "FK_Remuneraciones_Cuenta_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RemuneracionesPorLiquidaciones",
                columns: table => new
                {
                    CodigoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemuneracionesPorLiquidaciones", x => new { x.CodigoRemuneracion, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_RemuneracionesPorLiquidaciones_Liquidaciones_CodigoLiquidaci~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemuneracionesPorLiquidaciones_Remuneraciones_CodigoRemunera~",
                        column: x => x.CodigoRemuneracion,
                        principalTable: "Remuneraciones",
                        principalColumn: "CodigoRemuneracion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CatalogoRetenciones",
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
                name: "IX_Liquidaciones_CodigoLiquidacionGeneral",
                table: "Liquidaciones",
                column: "CodigoLiquidacionGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_PagosLiquidaciones_CodigoLiquidacion",
                table: "PagosLiquidaciones",
                column: "CodigoLiquidacion");

            migrationBuilder.CreateIndex(
                name: "IX_Remuneraciones_NumeroCuenta",
                table: "Remuneraciones",
                column: "NumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_RemuneracionesPorLiquidaciones_CodigoLiquidacionPersonal",
                table: "RemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal");

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidaciones_LiquidacionesGenerales_CodigoLiquidacionGeneral",
                table: "Liquidaciones",
                column: "CodigoLiquidacionGeneral",
                principalTable: "LiquidacionesGenerales",
                principalColumn: "CodigoLiquidacionGeneral");
        }
    }
}
