using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EliminandoModalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModalidadesPorContrato");

            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.RenameColumn(
                name: "MontoPorHora",
                table: "Contratos",
                newName: "ValorHora");

            migrationBuilder.RenameColumn(
                name: "MontoFijo",
                table: "Contratos",
                newName: "ValorBlanco");

            migrationBuilder.RenameColumn(
                name: "FechaContrato",
                table: "Contratos",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "CodigoContrato",
                table: "Contratos",
                newName: "Codigo");

            migrationBuilder.AddColumn<string>(
                name: "AcuerdoCodigo",
                table: "LiquidacionesPersonales",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Sueldo",
                table: "Contratos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TipoSueldo",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesPersonales_AcuerdoCodigo",
                table: "LiquidacionesPersonales",
                column: "AcuerdoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_AcuerdoCodigo",
                table: "LiquidacionesPersonales",
                column: "AcuerdoCodigo",
                principalTable: "Contratos",
                principalColumn: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_AcuerdoCodigo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropIndex(
                name: "IX_LiquidacionesPersonales_AcuerdoCodigo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "AcuerdoCodigo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "TipoSueldo",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "ValorHora",
                table: "Contratos",
                newName: "MontoPorHora");

            migrationBuilder.RenameColumn(
                name: "ValorBlanco",
                table: "Contratos",
                newName: "MontoFijo");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Contratos",
                newName: "FechaContrato");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Contratos",
                newName: "CodigoContrato");

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    CodigoModalidad = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.CodigoModalidad);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModalidadesPorContrato",
                columns: table => new
                {
                    CodigoModalidad = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoContrato = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Modalidades",
                columns: new[] { "CodigoModalidad", "Descripcion" },
                values: new object[,]
                {
                    { "10", "mensual fijo" },
                    { "12", "mensual fijo + horas extras" },
                    { "20", "quincena por hora" },
                    { "22", "quincenal fijo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadesPorContrato_CodigoContrato",
                table: "ModalidadesPorContrato",
                column: "CodigoContrato");
        }
    }
}
