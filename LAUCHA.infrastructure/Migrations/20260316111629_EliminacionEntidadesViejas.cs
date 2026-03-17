using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionEntidadesViejas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Conceptos_ConceptoNumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Cuenta_CuentaNumeroCuenta",
                table: "Creditos");

            migrationBuilder.DropTable(
                name: "DescuentosPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "NoRemuneracionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "RetencionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "NoRemuneraciones");

            migrationBuilder.DropTable(
                name: "Retenciones");

            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropIndex(
                name: "IX_Creditos_ConceptoNumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropIndex(
                name: "IX_Creditos_CuentaNumeroCuenta",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "ConceptoNumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "CuentaNumeroCuenta",
                table: "Creditos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConceptoNumeroConcepto",
                table: "Creditos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuentaNumeroCuenta",
                table: "Creditos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    NumeroConcepto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreConcepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.NumeroConcepto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstadoCuenta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.NumeroCuenta);
                    table.ForeignKey(
                        name: "FK_Cuenta_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroConcepto = table.Column<int>(type: "int", nullable: true),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.CodigoDescuento);
                    table.ForeignKey(
                        name: "FK_Descuentos_Conceptos_NumeroConcepto",
                        column: x => x.NumeroConcepto,
                        principalTable: "Conceptos",
                        principalColumn: "NumeroConcepto");
                    table.ForeignKey(
                        name: "FK_Descuentos_Cuenta_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoRemuneraciones",
                columns: table => new
                {
                    CodigoNoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoRemuneraciones", x => x.CodigoNoRemuneracion);
                    table.ForeignKey(
                        name: "FK_NoRemuneraciones_Cuenta_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Retenciones",
                columns: table => new
                {
                    CodigoRetencion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retenciones", x => x.CodigoRetencion);
                    table.ForeignKey(
                        name: "FK_Retenciones_Cuenta_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DescuentosPorLiquidaciones",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosPorLiquidaciones", x => new { x.CodigoDescuento, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_DescuentosPorLiquidaciones_Descuentos_CodigoDescuento",
                        column: x => x.CodigoDescuento,
                        principalTable: "Descuentos",
                        principalColumn: "CodigoDescuento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescuentosPorLiquidaciones_Liquidaciones_CodigoLiquidacionPe~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NoRemuneracionesPorLiquidaciones",
                columns: table => new
                {
                    CodigoNoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoRemuneracionesPorLiquidaciones", x => new { x.CodigoNoRemuneracion, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_NoRemuneracionesPorLiquidaciones_Liquidaciones_CodigoLiquida~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoRemuneracionesPorLiquidaciones_NoRemuneraciones_CodigoNoRe~",
                        column: x => x.CodigoNoRemuneracion,
                        principalTable: "NoRemuneraciones",
                        principalColumn: "CodigoNoRemuneracion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionesPorLiquidaciones",
                columns: table => new
                {
                    CodigoRetencion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionesPorLiquidaciones", x => new { x.CodigoRetencion, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_RetencionesPorLiquidaciones_Liquidaciones_CodigoLiquidacionP~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "Liquidaciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetencionesPorLiquidaciones_Retenciones_CodigoRetencion",
                        column: x => x.CodigoRetencion,
                        principalTable: "Retenciones",
                        principalColumn: "CodigoRetencion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_ConceptoNumeroConcepto",
                table: "Creditos",
                column: "ConceptoNumeroConcepto");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_CuentaNumeroCuenta",
                table: "Creditos",
                column: "CuentaNumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_DniEmpleado",
                table: "Cuenta",
                column: "DniEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descuentos_NumeroConcepto",
                table: "Descuentos",
                column: "NumeroConcepto");

            migrationBuilder.CreateIndex(
                name: "IX_Descuentos_NumeroCuenta",
                table: "Descuentos",
                column: "NumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosPorLiquidaciones_CodigoLiquidacionPersonal",
                table: "DescuentosPorLiquidaciones",
                column: "CodigoLiquidacionPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_NoRemuneraciones_NumeroCuenta",
                table: "NoRemuneraciones",
                column: "NumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_NoRemuneracionesPorLiquidaciones_CodigoLiquidacionPersonal",
                table: "NoRemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Retenciones_NumeroCuenta",
                table: "Retenciones",
                column: "NumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_RetencionesPorLiquidaciones_CodigoLiquidacionPersonal",
                table: "RetencionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal");

            migrationBuilder.AddForeignKey(
                name: "FK_Creditos_Conceptos_ConceptoNumeroConcepto",
                table: "Creditos",
                column: "ConceptoNumeroConcepto",
                principalTable: "Conceptos",
                principalColumn: "NumeroConcepto");

            migrationBuilder.AddForeignKey(
                name: "FK_Creditos_Cuenta_CuentaNumeroCuenta",
                table: "Creditos",
                column: "CuentaNumeroCuenta",
                principalTable: "Cuenta",
                principalColumn: "NumeroCuenta");
        }
    }
}
