using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracionCreditos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Conceptos_NumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Cuentas_NumeroCuenta",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Empleados_DniEmpleado",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Descuentos_Cuentas_NumeroCuenta",
                table: "Descuentos");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosPorLiquidaciones_LiquidacionesPersonales_CodigoLiq~",
                table: "DescuentosPorLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLiquidacion_LiquidacionesPersonales_CodigoLiquidacion",
                table: "ItemLiquidacion");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoAcuerdo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropForeignKey(
                name: "FK_NoRemuneraciones_Cuentas_NumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_NoRemuneracionesPorLiquidaciones_LiquidacionesPersonales_Cod~",
                table: "NoRemuneracionesPorLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosLiquidaciones_LiquidacionesPersonales_CodigoLiquidacion",
                table: "PagosLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Remuneraciones_Cuentas_NumeroCuenta",
                table: "Remuneraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_RemuneracionesPorLiquidaciones_LiquidacionesPersonales_Codig~",
                table: "RemuneracionesPorLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Retenciones_Cuentas_NumeroCuenta",
                table: "Retenciones");

            migrationBuilder.DropForeignKey(
                name: "FK_RetencionesPorLiquidaciones_LiquidacionesPersonales_CodigoLi~",
                table: "RetencionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "AcuerdoBlanco");

            migrationBuilder.DropTable(
                name: "PagosCreditos");

            migrationBuilder.DropIndex(
                name: "IX_Creditos_NumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LiquidacionesPersonales",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "CantidadCuotasFaltantes",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "SePagaQuincenal",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "Suspendido",
                table: "Creditos");

            migrationBuilder.RenameTable(
                name: "LiquidacionesPersonales",
                newName: "Liquidaciones");

            migrationBuilder.RenameTable(
                name: "Cuentas",
                newName: "Cuenta");

            migrationBuilder.RenameColumn(
                name: "NumeroCuenta",
                table: "Creditos",
                newName: "DniEmpleado");

            migrationBuilder.RenameColumn(
                name: "NumeroConcepto",
                table: "Creditos",
                newName: "ModoPago");

            migrationBuilder.RenameColumn(
                name: "MontoPagado",
                table: "Creditos",
                newName: "MontoPrestado");

            migrationBuilder.RenameColumn(
                name: "Monto",
                table: "Creditos",
                newName: "MontoDevolver");

            migrationBuilder.RenameColumn(
                name: "CantidadCuotasPagadas",
                table: "Creditos",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "CantidadCuotasOriginales",
                table: "Creditos",
                newName: "CantidadCuotas");

            migrationBuilder.RenameColumn(
                name: "CodigoCredito",
                table: "Creditos",
                newName: "Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_Creditos_NumeroCuenta",
                table: "Creditos",
                newName: "IX_Creditos_DniEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_LiquidacionesPersonales_CodigoLiquidacionGeneral",
                table: "Liquidaciones",
                newName: "IX_Liquidaciones_CodigoLiquidacionGeneral");

            migrationBuilder.RenameIndex(
                name: "IX_LiquidacionesPersonales_CodigoAcuerdo",
                table: "Liquidaciones",
                newName: "IX_Liquidaciones_CodigoAcuerdo");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_DniEmpleado",
                table: "Cuenta",
                newName: "IX_Cuenta_DniEmpleado");

            migrationBuilder.AddColumn<int>(
                name: "ConceptoNumeroConcepto",
                table: "Creditos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Creacion",
                table: "Creditos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CuentaNumeroCuenta",
                table: "Creditos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liquidaciones",
                table: "Liquidaciones",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta",
                column: "NumeroCuenta");

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Nro = table.Column<int>(type: "int", nullable: false),
                    CodigoCredito = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Creacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    QuincenaDebitar = table.Column<int>(type: "int", nullable: false),
                    MesDebitar = table.Column<int>(type: "int", nullable: false),
                    AnioDebitar = table.Column<int>(type: "int", nullable: false),
                    NroItem = table.Column<int>(type: "int", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => new { x.Nro, x.CodigoCredito });
                    table.ForeignKey(
                        name: "FK_Cuotas_Creditos_CodigoCredito",
                        column: x => x.CodigoCredito,
                        principalTable: "Creditos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cuotas_ItemLiquidacion_CodigoLiquidacion_NroItem",
                        columns: x => new { x.CodigoLiquidacion, x.NroItem },
                        principalTable: "ItemLiquidacion",
                        principalColumns: new[] { "CodigoLiquidacion", "NroItem" },
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Cuotas_CodigoCredito",
                table: "Cuotas",
                column: "CodigoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoLiquidacion_NroItem",
                table: "Cuotas",
                columns: new[] { "CodigoLiquidacion", "NroItem" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Creditos_Empleados_DniEmpleado",
                table: "Creditos",
                column: "DniEmpleado",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Empleados_DniEmpleado",
                table: "Cuenta",
                column: "DniEmpleado",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descuentos_Cuenta_NumeroCuenta",
                table: "Descuentos",
                column: "NumeroCuenta",
                principalTable: "Cuenta",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosPorLiquidaciones_Liquidaciones_CodigoLiquidacionPe~",
                table: "DescuentosPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLiquidacion_Liquidaciones_CodigoLiquidacion",
                table: "ItemLiquidacion",
                column: "CodigoLiquidacion",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidaciones_Acuerdos_CodigoAcuerdo",
                table: "Liquidaciones",
                column: "CodigoAcuerdo",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Liquidaciones_LiquidacionesGenerales_CodigoLiquidacionGeneral",
                table: "Liquidaciones",
                column: "CodigoLiquidacionGeneral",
                principalTable: "LiquidacionesGenerales",
                principalColumn: "CodigoLiquidacionGeneral");

            migrationBuilder.AddForeignKey(
                name: "FK_NoRemuneraciones_Cuenta_NumeroCuenta",
                table: "NoRemuneraciones",
                column: "NumeroCuenta",
                principalTable: "Cuenta",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoRemuneracionesPorLiquidaciones_Liquidaciones_CodigoLiquida~",
                table: "NoRemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosLiquidaciones_Liquidaciones_CodigoLiquidacion",
                table: "PagosLiquidaciones",
                column: "CodigoLiquidacion",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Remuneraciones_Cuenta_NumeroCuenta",
                table: "Remuneraciones",
                column: "NumeroCuenta",
                principalTable: "Cuenta",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemuneracionesPorLiquidaciones_Liquidaciones_CodigoLiquidaci~",
                table: "RemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retenciones_Cuenta_NumeroCuenta",
                table: "Retenciones",
                column: "NumeroCuenta",
                principalTable: "Cuenta",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RetencionesPorLiquidaciones_Liquidaciones_CodigoLiquidacionP~",
                table: "RetencionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Conceptos_ConceptoNumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Cuenta_CuentaNumeroCuenta",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Empleados_DniEmpleado",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Empleados_DniEmpleado",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Descuentos_Cuenta_NumeroCuenta",
                table: "Descuentos");

            migrationBuilder.DropForeignKey(
                name: "FK_DescuentosPorLiquidaciones_Liquidaciones_CodigoLiquidacionPe~",
                table: "DescuentosPorLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemLiquidacion_Liquidaciones_CodigoLiquidacion",
                table: "ItemLiquidacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquidaciones_Acuerdos_CodigoAcuerdo",
                table: "Liquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquidaciones_LiquidacionesGenerales_CodigoLiquidacionGeneral",
                table: "Liquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_NoRemuneraciones_Cuenta_NumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_NoRemuneracionesPorLiquidaciones_Liquidaciones_CodigoLiquida~",
                table: "NoRemuneracionesPorLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosLiquidaciones_Liquidaciones_CodigoLiquidacion",
                table: "PagosLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Remuneraciones_Cuenta_NumeroCuenta",
                table: "Remuneraciones");

            migrationBuilder.DropForeignKey(
                name: "FK_RemuneracionesPorLiquidaciones_Liquidaciones_CodigoLiquidaci~",
                table: "RemuneracionesPorLiquidaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Retenciones_Cuenta_NumeroCuenta",
                table: "Retenciones");

            migrationBuilder.DropForeignKey(
                name: "FK_RetencionesPorLiquidaciones_Liquidaciones_CodigoLiquidacionP~",
                table: "RetencionesPorLiquidaciones");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropIndex(
                name: "IX_Creditos_ConceptoNumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropIndex(
                name: "IX_Creditos_CuentaNumeroCuenta",
                table: "Creditos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Liquidaciones",
                table: "Liquidaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta");

            migrationBuilder.DropColumn(
                name: "ConceptoNumeroConcepto",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "Creacion",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "CuentaNumeroCuenta",
                table: "Creditos");

            migrationBuilder.RenameTable(
                name: "Liquidaciones",
                newName: "LiquidacionesPersonales");

            migrationBuilder.RenameTable(
                name: "Cuenta",
                newName: "Cuentas");

            migrationBuilder.RenameColumn(
                name: "MontoPrestado",
                table: "Creditos",
                newName: "MontoPagado");

            migrationBuilder.RenameColumn(
                name: "MontoDevolver",
                table: "Creditos",
                newName: "Monto");

            migrationBuilder.RenameColumn(
                name: "ModoPago",
                table: "Creditos",
                newName: "NumeroConcepto");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Creditos",
                newName: "CantidadCuotasPagadas");

            migrationBuilder.RenameColumn(
                name: "DniEmpleado",
                table: "Creditos",
                newName: "NumeroCuenta");

            migrationBuilder.RenameColumn(
                name: "CantidadCuotas",
                table: "Creditos",
                newName: "CantidadCuotasOriginales");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Creditos",
                newName: "CodigoCredito");

            migrationBuilder.RenameIndex(
                name: "IX_Creditos_DniEmpleado",
                table: "Creditos",
                newName: "IX_Creditos_NumeroCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Liquidaciones_CodigoLiquidacionGeneral",
                table: "LiquidacionesPersonales",
                newName: "IX_LiquidacionesPersonales_CodigoLiquidacionGeneral");

            migrationBuilder.RenameIndex(
                name: "IX_Liquidaciones_CodigoAcuerdo",
                table: "LiquidacionesPersonales",
                newName: "IX_LiquidacionesPersonales_CodigoAcuerdo");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_DniEmpleado",
                table: "Cuentas",
                newName: "IX_Cuentas_DniEmpleado");

            migrationBuilder.AddColumn<int>(
                name: "CantidadCuotasFaltantes",
                table: "Creditos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_LiquidacionesPersonales",
                table: "LiquidacionesPersonales",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas",
                column: "NumeroCuenta");

            migrationBuilder.CreateTable(
                name: "AcuerdoBlanco",
                columns: table => new
                {
                    CodigoAcuerdoBlanco = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoCodigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoContrato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcuerdoBlanco", x => x.CodigoAcuerdoBlanco);
                    table.ForeignKey(
                        name: "FK_AcuerdoBlanco_Acuerdos_ContratoCodigo",
                        column: x => x.ContratoCodigo,
                        principalTable: "Acuerdos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagosCreditos",
                columns: table => new
                {
                    CodigoCredito = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoDescuento = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_NumeroConcepto",
                table: "Creditos",
                column: "NumeroConcepto");

            migrationBuilder.CreateIndex(
                name: "IX_AcuerdoBlanco_ContratoCodigo",
                table: "AcuerdoBlanco",
                column: "ContratoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PagosCreditos_CodigoDescuento",
                table: "PagosCreditos",
                column: "CodigoDescuento");

            migrationBuilder.AddForeignKey(
                name: "FK_Creditos_Conceptos_NumeroConcepto",
                table: "Creditos",
                column: "NumeroConcepto",
                principalTable: "Conceptos",
                principalColumn: "NumeroConcepto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Creditos_Cuentas_NumeroCuenta",
                table: "Creditos",
                column: "NumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Empleados_DniEmpleado",
                table: "Cuentas",
                column: "DniEmpleado",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Descuentos_Cuentas_NumeroCuenta",
                table: "Descuentos",
                column: "NumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescuentosPorLiquidaciones_LiquidacionesPersonales_CodigoLiq~",
                table: "DescuentosPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "LiquidacionesPersonales",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLiquidacion_LiquidacionesPersonales_CodigoLiquidacion",
                table: "ItemLiquidacion",
                column: "CodigoLiquidacion",
                principalTable: "LiquidacionesPersonales",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoAcuerdo",
                table: "LiquidacionesPersonales",
                column: "CodigoAcuerdo",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                table: "LiquidacionesPersonales",
                column: "CodigoLiquidacionGeneral",
                principalTable: "LiquidacionesGenerales",
                principalColumn: "CodigoLiquidacionGeneral");

            migrationBuilder.AddForeignKey(
                name: "FK_NoRemuneraciones_Cuentas_NumeroCuenta",
                table: "NoRemuneraciones",
                column: "NumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoRemuneracionesPorLiquidaciones_LiquidacionesPersonales_Cod~",
                table: "NoRemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "LiquidacionesPersonales",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosLiquidaciones_LiquidacionesPersonales_CodigoLiquidacion",
                table: "PagosLiquidaciones",
                column: "CodigoLiquidacion",
                principalTable: "LiquidacionesPersonales",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Remuneraciones_Cuentas_NumeroCuenta",
                table: "Remuneraciones",
                column: "NumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemuneracionesPorLiquidaciones_LiquidacionesPersonales_Codig~",
                table: "RemuneracionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "LiquidacionesPersonales",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retenciones_Cuentas_NumeroCuenta",
                table: "Retenciones",
                column: "NumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RetencionesPorLiquidaciones_LiquidacionesPersonales_CodigoLi~",
                table: "RetencionesPorLiquidaciones",
                column: "CodigoLiquidacionPersonal",
                principalTable: "LiquidacionesPersonales",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
