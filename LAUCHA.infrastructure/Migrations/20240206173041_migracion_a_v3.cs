using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migracion_a_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Adicionales",
                columns: table => new
                {
                    CodigoAdicional = table.Column<string>(type: "varchar(255)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionales", x => x.CodigoAdicional);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    NumeroConcepto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreConcepto = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.NumeroConcepto);
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
                name: "LiquidacionesGenerales",
                columns: table => new
                {
                    CodigoLiquidacionGeneral = table.Column<string>(type: "varchar(255)", nullable: false),
                    TotalRemuneracion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRetencion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDescuentos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InicioPeriodo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinPeriodo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidacionesGenerales", x => x.CodigoLiquidacionGeneral);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    CodigoModalidad = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.CodigoModalidad);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionesFijas",
                columns: table => new
                {
                    CodigoRetencionFija = table.Column<string>(type: "varchar(255)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionesFijas", x => x.CodigoRetencionFija);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false),
                    TipoContrato = table.Column<string>(type: "longtext", nullable: false),
                    MontoPorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoFijo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "LiquidacionesPersonales",
                columns: table => new
                {
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false),
                    TotalRemuneraciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRetenciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDescuentos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    InicioPeriodo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinPeriodo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodigoLiquidacionGeneral = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidacionesPersonales", x => x.CodigoLiquidacion);
                    table.ForeignKey(
                        name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                        column: x => x.CodigoLiquidacionGeneral,
                        principalTable: "LiquidacionesGenerales",
                        principalColumn: "CodigoLiquidacionGeneral",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HistorialRetencionesFijas",
                columns: table => new
                {
                    CodigoRetencionFija = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaFinVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcuerdosBlancos",
                columns: table => new
                {
                    CodigoAcuerdoBlanco = table.Column<string>(type: "varchar(255)", nullable: false),
                    Concepto = table.Column<string>(type: "longtext", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcuerdosBlancos", x => x.CodigoAcuerdoBlanco);
                    table.ForeignKey(
                        name: "FK_AcuerdosBlancos_Contratos_CodigoContrato",
                        column: x => x.CodigoContrato,
                        principalTable: "Contratos",
                        principalColumn: "CodigoContrato",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdicionalesPorContrato",
                columns: table => new
                {
                    CodigoAdicional = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdicionalesPorContrato", x => new { x.CodigoContrato, x.CodigoAdicional });
                    table.ForeignKey(
                        name: "FK_AdicionalesPorContrato_Adicionales_CodigoAdicional",
                        column: x => x.CodigoAdicional,
                        principalTable: "Adicionales",
                        principalColumn: "CodigoAdicional",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdicionalesPorContrato_Contratos_CodigoContrato",
                        column: x => x.CodigoContrato,
                        principalTable: "Contratos",
                        principalColumn: "CodigoContrato",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModalidadesPorContrato",
                columns: table => new
                {
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoModalidad = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadesPorContrato", x => new { x.CodigoModalidad, x.CodigoContrato });
                    table.ForeignKey(
                        name: "FK_ModalidadesPorContrato_Contratos_CodigoContrato",
                        column: x => x.CodigoContrato,
                        principalTable: "Contratos",
                        principalColumn: "CodigoContrato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalidadesPorContrato_Modalidades_CodigoModalidad",
                        column: x => x.CodigoModalidad,
                        principalTable: "Modalidades",
                        principalColumn: "CodigoModalidad",
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
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false),
                    NumeroConcepto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.CodigoCredito);
                    table.ForeignKey(
                        name: "FK_Creditos_Conceptos_NumeroConcepto",
                        column: x => x.NumeroConcepto,
                        principalTable: "Conceptos",
                        principalColumn: "NumeroConcepto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Creditos_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumeroConcepto = table.Column<int>(type: "int", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.CodigoDescuento);
                    table.ForeignKey(
                        name: "FK_Descuentos_Conceptos_NumeroConcepto",
                        column: x => x.NumeroConcepto,
                        principalTable: "Conceptos",
                        principalColumn: "NumeroConcepto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descuentos_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Remuneraciones",
                columns: table => new
                {
                    CodigoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EsBlanco = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remuneraciones", x => x.CodigoRemuneracion);
                    table.ForeignKey(
                        name: "FK_Remuneraciones_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Retenciones",
                columns: table => new
                {
                    CodigoRetencion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retenciones", x => x.CodigoRetencion);
                    table.ForeignKey(
                        name: "FK_Retenciones_Cuentas_NumeroCuenta",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionesFijasPorCuentas",
                columns: table => new
                {
                    NumeroCuenta = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoRetencionFija = table.Column<string>(type: "varchar(255)", nullable: false)
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
                        name: "FK_PagosLiquidaciones_LiquidacionesPersonales_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
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
                name: "DescuentosPorLiquidaciones",
                columns: table => new
                {
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
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
                        name: "FK_DescuentosPorLiquidaciones_LiquidacionesPersonales_CodigoLiq~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RemuneracionesPorLiquidaciones",
                columns: table => new
                {
                    CodigoRemuneracion = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemuneracionesPorLiquidaciones", x => new { x.CodigoRemuneracion, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_RemuneracionesPorLiquidaciones_LiquidacionesPersonales_Codig~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RemuneracionesPorLiquidaciones_Remuneraciones_CodigoRemunera~",
                        column: x => x.CodigoRemuneracion,
                        principalTable: "Remuneraciones",
                        principalColumn: "CodigoRemuneracion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RetencionesPorLiquidaciones",
                columns: table => new
                {
                    CodigoRetencion = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoLiquidacionPersonal = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionesPorLiquidaciones", x => new { x.CodigoRetencion, x.CodigoLiquidacionPersonal });
                    table.ForeignKey(
                        name: "FK_RetencionesPorLiquidaciones_LiquidacionesPersonales_CodigoLi~",
                        column: x => x.CodigoLiquidacionPersonal,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "CodigoLiquidacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetencionesPorLiquidaciones_Retenciones_CodigoRetencion",
                        column: x => x.CodigoRetencion,
                        principalTable: "Retenciones",
                        principalColumn: "CodigoRetencion",
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
                name: "IX_AcuerdosBlancos_CodigoContrato",
                table: "AcuerdosBlancos",
                column: "CodigoContrato",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdicionalesPorContrato_CodigoAdicional",
                table: "AdicionalesPorContrato",
                column: "CodigoAdicional");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DniEmpleado",
                table: "Contratos",
                column: "DniEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_NumeroConcepto",
                table: "Creditos",
                column: "NumeroConcepto");

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
                name: "IX_CuotasPorLiquidacionPersonal_CodigoLiquidacion",
                table: "CuotasPorLiquidacionPersonal",
                column: "CodigoLiquidacion");

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
                name: "IX_LiquidacionesPersonales_CodigoLiquidacionGeneral",
                table: "LiquidacionesPersonales",
                column: "CodigoLiquidacionGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadesPorContrato_CodigoContrato",
                table: "ModalidadesPorContrato",
                column: "CodigoContrato");

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

            migrationBuilder.CreateIndex(
                name: "IX_Retenciones_NumeroCuenta",
                table: "Retenciones",
                column: "NumeroCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_RetencionesFijasPorCuentas_CodigoRetencionFija",
                table: "RetencionesFijasPorCuentas",
                column: "CodigoRetencionFija");

            migrationBuilder.CreateIndex(
                name: "IX_RetencionesPorLiquidaciones_CodigoLiquidacionPersonal",
                table: "RetencionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Subcuotas_CodigoCuota",
                table: "Subcuotas",
                column: "CodigoCuota");

            migrationBuilder.CreateIndex(
                name: "IX_SubcuotasPorLiquidacion_CodigoLiquidacion",
                table: "SubcuotasPorLiquidacion",
                column: "CodigoLiquidacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcuerdosBlancos");

            migrationBuilder.DropTable(
                name: "AdicionalesPorContrato");

            migrationBuilder.DropTable(
                name: "CuotasPorLiquidacionPersonal");

            migrationBuilder.DropTable(
                name: "DescuentosPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "HistorialRetencionesFijas");

            migrationBuilder.DropTable(
                name: "ModalidadesPorContrato");

            migrationBuilder.DropTable(
                name: "PagosLiquidaciones");

            migrationBuilder.DropTable(
                name: "RemuneracionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "RetencionesFijasPorCuentas");

            migrationBuilder.DropTable(
                name: "RetencionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "SubcuotasPorLiquidacion");

            migrationBuilder.DropTable(
                name: "Adicionales");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.DropTable(
                name: "Remuneraciones");

            migrationBuilder.DropTable(
                name: "RetencionesFijas");

            migrationBuilder.DropTable(
                name: "Retenciones");

            migrationBuilder.DropTable(
                name: "LiquidacionesPersonales");

            migrationBuilder.DropTable(
                name: "Subcuotas");

            migrationBuilder.DropTable(
                name: "LiquidacionesGenerales");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Creditos");

            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
