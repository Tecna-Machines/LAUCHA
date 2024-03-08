using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cambioscreditossincuotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuotasPorLiquidacionPersonal");

            migrationBuilder.DropTable(
                name: "SubcuotasPorLiquidacion");

            migrationBuilder.DropTable(
                name: "Subcuotas");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.AddColumn<int>(
                name: "CantidadCuotasFaltantes",
                table: "Creditos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadCuotasOriginales",
                table: "Creditos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadCuotasPagadas",
                table: "Creditos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoPagado",
                table: "Creditos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "SePagaQuincenal",
                table: "Creditos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Suspendido",
                table: "Creditos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PagosCreditos",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoCredito = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosCreditos", x => new { x.CodigoCredito, x.CodigoDescuento });
                    table.ForeignKey(
                        name: "FK_PagosCreditos_Creditos_CodigoCredito",
                        column: x => x.CodigoCredito,
                        principalTable: "Creditos",
                        principalColumn: "CodigoCredito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagosCreditos_Descuentos_CodigoDescuento",
                        column: x => x.CodigoDescuento,
                        principalTable: "Descuentos",
                        principalColumn: "CodigoDescuento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PagosCreditos_CodigoDescuento",
                table: "PagosCreditos",
                column: "CodigoDescuento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagosCreditos");

            migrationBuilder.DropColumn(
                name: "CantidadCuotasFaltantes",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "CantidadCuotasOriginales",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "CantidadCuotasPagadas",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "MontoPagado",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "SePagaQuincenal",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "Suspendido",
                table: "Creditos");

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    CodigoCuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoCredito = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaDebePagar = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.CodigoCuota);
                    table.ForeignKey(
                        name: "FK_Cuotas_Creditos_CodigoCredito",
                        column: x => x.CodigoCredito,
                        principalTable: "Creditos",
                        principalColumn: "CodigoCredito",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CuotasPorLiquidacionPersonal",
                columns: table => new
                {
                    CodigoCuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasPorLiquidacionPersonal", x => new { x.CodigoCuota, x.CodigoLiquidacion });
                    table.ForeignKey(
                        name: "FK_CuotasPorLiquidacionPersonal_Cuotas_CodigoCuota",
                        column: x => x.CodigoCuota,
                        principalTable: "Cuotas",
                        principalColumn: "CodigoCuota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuotasPorLiquidacionPersonal_LiquidacionesPersonales_CodigoL~",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subcuotas",
                columns: table => new
                {
                    CodigoSubcuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoCuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaDebePagar = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcuotas", x => x.CodigoSubcuota);
                    table.ForeignKey(
                        name: "FK_Subcuotas_Cuotas_CodigoCuota",
                        column: x => x.CodigoCuota,
                        principalTable: "Cuotas",
                        principalColumn: "CodigoCuota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubcuotasPorLiquidacion",
                columns: table => new
                {
                    CodigoSubcuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubcuotasPorLiquidacion", x => new { x.CodigoSubcuota, x.CodigoLiquidacion });
                    table.ForeignKey(
                        name: "FK_SubcuotasPorLiquidacion_LiquidacionesPersonales_CodigoLiquid~",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubcuotasPorLiquidacion_Subcuotas_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "Subcuotas",
                        principalColumn: "CodigoSubcuota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoCredito",
                table: "Cuotas",
                column: "CodigoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasPorLiquidacionPersonal_CodigoLiquidacion",
                table: "CuotasPorLiquidacionPersonal",
                column: "CodigoLiquidacion");

            migrationBuilder.CreateIndex(
                name: "IX_Subcuotas_CodigoCuota",
                table: "Subcuotas",
                column: "CodigoCuota");

            migrationBuilder.CreateIndex(
                name: "IX_SubcuotasPorLiquidacion_CodigoLiquidacion",
                table: "SubcuotasPorLiquidacion",
                column: "CodigoLiquidacion");
        }
    }
}
