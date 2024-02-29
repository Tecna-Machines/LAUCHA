using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correccionreleacionNoRemuCuenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoRemuneraciones_Cuentas_CuentaNumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.DropIndex(
                name: "IX_NoRemuneraciones_CuentaNumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.DropColumn(
                name: "CuentaNumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCuenta",
                table: "NoRemuneraciones",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_NoRemuneraciones_NumeroCuenta",
                table: "NoRemuneraciones",
                column: "NumeroCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_NoRemuneraciones_Cuentas_NumeroCuenta",
                table: "NoRemuneraciones",
                column: "NumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoRemuneraciones_Cuentas_NumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.DropIndex(
                name: "IX_NoRemuneraciones_NumeroCuenta",
                table: "NoRemuneraciones");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCuenta",
                table: "NoRemuneraciones",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "CuentaNumeroCuenta",
                table: "NoRemuneraciones",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NoRemuneraciones_CuentaNumeroCuenta",
                table: "NoRemuneraciones",
                column: "CuentaNumeroCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_NoRemuneraciones_Cuentas_CuentaNumeroCuenta",
                table: "NoRemuneraciones",
                column: "CuentaNumeroCuenta",
                principalTable: "Cuentas",
                principalColumn: "NumeroCuenta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
