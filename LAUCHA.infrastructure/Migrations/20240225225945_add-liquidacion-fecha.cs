using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addliquidacionfecha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descuentos_Conceptos_NumeroConcepto",
                table: "Descuentos");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                table: "LiquidacionesPersonales");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoLiquidacionGeneral",
                table: "LiquidacionesPersonales",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLiquidacion",
                table: "LiquidacionesPersonales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "NumeroConcepto",
                table: "Descuentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Descuentos_Conceptos_NumeroConcepto",
                table: "Descuentos",
                column: "NumeroConcepto",
                principalTable: "Conceptos",
                principalColumn: "NumeroConcepto");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                table: "LiquidacionesPersonales",
                column: "CodigoLiquidacionGeneral",
                principalTable: "LiquidacionesGenerales",
                principalColumn: "CodigoLiquidacionGeneral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descuentos_Conceptos_NumeroConcepto",
                table: "Descuentos");

            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "FechaLiquidacion",
                table: "LiquidacionesPersonales");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoLiquidacionGeneral",
                table: "LiquidacionesPersonales",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumeroConcepto",
                table: "Descuentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Descuentos_Conceptos_NumeroConcepto",
                table: "Descuentos",
                column: "NumeroConcepto",
                principalTable: "Conceptos",
                principalColumn: "NumeroConcepto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_LiquidacionesGenerales_CodigoLiquida~",
                table: "LiquidacionesPersonales",
                column: "CodigoLiquidacionGeneral",
                principalTable: "LiquidacionesGenerales",
                principalColumn: "CodigoLiquidacionGeneral",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
