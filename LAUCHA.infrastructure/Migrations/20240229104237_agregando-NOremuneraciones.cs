using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class agregandoNOremuneraciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoRemuneraciones",
                columns: table => new
                {
                    CodigoNoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "longtext", nullable: false),
                    CuentaNumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoRemuneraciones", x => x.CodigoNoRemuneracion);
                    table.ForeignKey(
                        name: "FK_NoRemuneraciones_Cuentas_CuentaNumeroCuenta",
                        column: x => x.CuentaNumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoRemuneracionesPorLiquidaciones",
                columns: table => new
                {
                    CodigoNoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoRemuneracionesPorLiquidaciones", x => new { x.CodigoNoRemuneracion, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_NoRemuneracionesPorLiquidaciones_LiquidacionesPersonales_Cod~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoRemuneracionesPorLiquidaciones_NoRemuneraciones_CodigoNoRe~",
                        column: x => x.CodigoNoRemuneracion,
                        principalTable: "NoRemuneraciones",
                        principalColumn: "CodigoNoRemuneracion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NoRemuneraciones_CuentaNumeroCuenta",
                table: "NoRemuneraciones",
                column: "CuentaNumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_NoRemuneracionesPorLiquidaciones_CodigoLiquidacionPersonal",
                table: "NoRemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoRemuneracionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "NoRemuneraciones");
        }
    }
}
