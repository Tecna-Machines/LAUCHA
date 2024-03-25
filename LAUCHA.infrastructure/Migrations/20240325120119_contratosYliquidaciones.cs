using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class contratosYliquidaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoContrato",
                table: "LiquidacionesPersonales",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSueldo",
                table: "LiquidacionesPersonales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_LiquidacionesPersonales_CodigoContrato",
                table: "LiquidacionesPersonales",
                column: "CodigoContrato");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_CodigoContrato",
                table: "LiquidacionesPersonales",
                column: "CodigoContrato",
                principalTable: "Contratos",
                principalColumn: "CodigoContrato",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Contratos_CodigoContrato",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropIndex(
                name: "IX_LiquidacionesPersonales_CodigoContrato",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "CodigoContrato",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "TotalSueldo",
                table: "LiquidacionesPersonales");
        }
    }
}
