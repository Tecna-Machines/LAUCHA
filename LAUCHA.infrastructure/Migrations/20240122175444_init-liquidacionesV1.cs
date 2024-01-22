using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initliquidacionesV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DescuentosFijos",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosFijos", x => x.CodigoDescuento);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Dni);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Liquidaciones",
                columns: table => new
                {
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false),
                    IngresoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EgresoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidaciones", x => x.CodigoLiquidacion);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialDescuentosFijos",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaFinVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialDescuentosFijos", x => new { x.CodigoDescuento, x.FechaFinVigencia });
                    table.ForeignKey(
                        name: "FK_HistorialDescuentosFijos_DescuentosFijos_CodigoDescuento",
                        column: x => x.CodigoDescuento,
                        principalTable: "DescuentosFijos",
                        principalColumn: "CodigoDescuento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false),
                    TipoContrato = table.Column<string>(type: "longtext", nullable: false),
                    MontoPorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Modalidad = table.Column<string>(type: "longtext", nullable: false),
                    FechaContrato = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.CodigoContrato);
                    table.ForeignKey(
                        name: "FK_Contratos_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false),
                    estadoCuenta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.NumeroCuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagosLiquidaciones",
                columns: table => new
                {
                    CodigoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosLiquidaciones", x => x.CodigoPago);
                    table.ForeignKey(
                        name: "FK_PagosLiquidaciones_Liquidaciones_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "Liquidaciones",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    CodigoCredito = table.Column<string>(type: "varchar(255)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.CodigoCredito);
                    table.ForeignKey(
                        name: "FK_Creditos_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DescuentosFijoPorCuentas",
                columns: table => new
                {
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosFijoPorCuentas", x => new { x.NumeroCuenta, x.CodigoDescuento });
                    table.ForeignKey(
                        name: "FK_DescuentosFijoPorCuentas_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescuentosFijoPorCuentas_DescuentosFijos_CodigoDescuento",
                        column: x => x.CodigoDescuento,
                        principalTable: "DescuentosFijos",
                        principalColumn: "CodigoDescuento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    NumeroTransaccion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Tipo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.NumeroTransaccion);
                    table.ForeignKey(
                        name: "FK_Transacciones_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    CodigoCuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaDebePagar = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodigoCredito = table.Column<string>(type: "varchar(255)", nullable: false)
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
                name: "LiquidacionesPorTransacciones",
                columns: table => new
                {
                    NumeroTransaccion = table.Column<long>(type: "bigint", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidacionesPorTransacciones", x => new { x.NumeroTransaccion, x.CodigoLiquidacion });
                    table.ForeignKey(
                        name: "FK_LiquidacionesPorTransacciones_Liquidaciones_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "Liquidaciones",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiquidacionesPorTransacciones_Transacciones_NumeroTransaccion",
                        column: x => x.NumeroTransaccion,
                        principalTable: "Transacciones",
                        principalColumn: "NumeroTransaccion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subcuotas",
                columns: table => new
                {
                    CodigoSubcuota = table.Column<string>(type: "varchar(255)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaDebePagar = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodigoCuota = table.Column<string>(type: "varchar(255)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DniEmpleado",
                table: "Contratos",
                column: "DniEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_NumeroCuenta",
                table: "Creditos",
                column: "NumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_DniEmpleado",
                table: "Cuentas",
                column: "DniEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoCredito",
                table: "Cuotas",
                column: "CodigoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosFijoPorCuentas_CodigoDescuento",
                table: "DescuentosFijoPorCuentas",
                column: "CodigoDescuento");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesPorTransacciones_CodigoLiquidacion",
                table: "LiquidacionesPorTransacciones",
                column: "CodigoLiquidacion");

            migrationBuilder.CreateIndex(
                name: "IX_PagosLiquidaciones_CodigoLiquidacion",
                table: "PagosLiquidaciones",
                column: "CodigoLiquidacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcuotas_CodigoCuota",
                table: "Subcuotas",
                column: "CodigoCuota");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_NumeroCuenta",
                table: "Transacciones",
                column: "NumeroCuenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "DescuentosFijoPorCuentas");

            migrationBuilder.DropTable(
                name: "HistorialDescuentosFijos");

            migrationBuilder.DropTable(
                name: "LiquidacionesPorTransacciones");

            migrationBuilder.DropTable(
                name: "PagosLiquidaciones");

            migrationBuilder.DropTable(
                name: "Subcuotas");

            migrationBuilder.DropTable(
                name: "DescuentosFijos");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Liquidaciones");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
