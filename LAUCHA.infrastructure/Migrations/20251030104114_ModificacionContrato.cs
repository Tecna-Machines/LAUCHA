using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionContrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicionales_Contratos_CodigoContrato",
                table: "Adicionales");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_AcuerdoCodigo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_CodigoContrato",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropTable(
                name: "AcuerdosBlancos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_LiquidacionesPersonales_AcuerdoCodigo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "AcuerdoCodigo",
                table: "LiquidacionesPersonales");

            migrationBuilder.CreateTable(
                name: "Acuerdos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorBlanco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoSueldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acuerdos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Acuerdos_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcuerdoBlanco",
                columns: table => new
                {
                    CodigoAcuerdoBlanco = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CodigoContrato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContratoCodigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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

            migrationBuilder.CreateIndex(
                name: "IX_AcuerdoBlanco_ContratoCodigo",
                table: "AcuerdoBlanco",
                column: "ContratoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Acuerdos_DniEmpleado",
                table: "Acuerdos",
                column: "DniEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicionales_Acuerdos_CodigoContrato",
                table: "Adicionales",
                column: "CodigoContrato",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoContrato",
                table: "LiquidacionesPersonales",
                column: "CodigoContrato",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicionales_Acuerdos_CodigoContrato",
                table: "Adicionales");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoContrato",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropTable(
                name: "AcuerdoBlanco");

            migrationBuilder.DropTable(
                name: "Acuerdos");

            migrationBuilder.AddColumn<string>(
                name: "AcuerdoCodigo",
                table: "LiquidacionesPersonales",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TipoContrato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoSueldo = table.Column<int>(type: "int", nullable: false),
                    ValorBlanco = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Contratos_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AcuerdosBlancos",
                columns: table => new
                {
                    CodigoAcuerdoBlanco = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcuerdosBlancos", x => x.CodigoAcuerdoBlanco);
                    table.ForeignKey(
                        name: "FK_AcuerdosBlancos_Contratos_CodigoContrato",
                        column: x => x.CodigoContrato,
                        principalTable: "Contratos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesPersonales_AcuerdoCodigo",
                table: "LiquidacionesPersonales",
                column: "AcuerdoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_AcuerdosBlancos_CodigoContrato",
                table: "AcuerdosBlancos",
                column: "CodigoContrato",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_DniEmpleado",
                table: "Contratos",
                column: "DniEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicionales_Contratos_CodigoContrato",
                table: "Adicionales",
                column: "CodigoContrato",
                principalTable: "Contratos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_AcuerdoCodigo",
                table: "LiquidacionesPersonales",
                column: "AcuerdoCodigo",
                principalTable: "Contratos",
                principalColumn: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_CodigoContrato",
                table: "LiquidacionesPersonales",
                column: "CodigoContrato",
                principalTable: "Contratos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
