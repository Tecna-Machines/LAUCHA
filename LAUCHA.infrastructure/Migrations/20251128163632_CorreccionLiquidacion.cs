using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionLiquidacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinPeriodo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "InicioPeriodo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "TotalRemuneraciones",
                table: "LiquidacionesPersonales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinPeriodo",
                table: "LiquidacionesPersonales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioPeriodo",
                table: "LiquidacionesPersonales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRemuneraciones",
                table: "LiquidacionesPersonales",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
