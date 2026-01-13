using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CambioEnCredito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_ItemLiquidacion_CodigoLiquidacion_NroItem",
                table: "Cuotas");

            migrationBuilder.DropIndex(
                name: "IX_Cuotas_CodigoLiquidacion_NroItem",
                table: "Cuotas");

            migrationBuilder.DropColumn(
                name: "NroItem",
                table: "Cuotas");

            migrationBuilder.AddColumn<string>(
                name: "CodigoLiquidacionAcreditacion",
                table: "Creditos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoLiquidacion",
                table: "Cuotas",
                column: "CodigoLiquidacion");

            migrationBuilder.CreateIndex(
                name: "IX_Creditos_CodigoLiquidacionAcreditacion",
                table: "Creditos",
                column: "CodigoLiquidacionAcreditacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Creditos_Liquidaciones_CodigoLiquidacionAcreditacion",
                table: "Creditos",
                column: "CodigoLiquidacionAcreditacion",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuotas_Liquidaciones_CodigoLiquidacion",
                table: "Cuotas",
                column: "CodigoLiquidacion",
                principalTable: "Liquidaciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditos_Liquidaciones_CodigoLiquidacionAcreditacion",
                table: "Creditos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_Liquidaciones_CodigoLiquidacion",
                table: "Cuotas");

            migrationBuilder.DropIndex(
                name: "IX_Cuotas_CodigoLiquidacion",
                table: "Cuotas");

            migrationBuilder.DropIndex(
                name: "IX_Creditos_CodigoLiquidacionAcreditacion",
                table: "Creditos");

            migrationBuilder.DropColumn(
                name: "CodigoLiquidacionAcreditacion",
                table: "Creditos");

            migrationBuilder.AddColumn<int>(
                name: "NroItem",
                table: "Cuotas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CodigoLiquidacion_NroItem",
                table: "Cuotas",
                columns: new[] { "CodigoLiquidacion", "NroItem" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cuotas_ItemLiquidacion_CodigoLiquidacion_NroItem",
                table: "Cuotas",
                columns: new[] { "CodigoLiquidacion", "NroItem" },
                principalTable: "ItemLiquidacion",
                principalColumns: new[] { "CodigoLiquidacion", "NroItem" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
