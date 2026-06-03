using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CambiosEnElAcuerdo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EsAutomatico",
                table: "ItemLiquidacion",
                newName: "generadoPorUsuario");

            migrationBuilder.RenameColumn(
                name: "ValorBlanco",
                table: "Acuerdos",
                newName: "ValorSueldoOJornal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "generadoPorUsuario",
                table: "ItemLiquidacion",
                newName: "EsAutomatico");

            migrationBuilder.RenameColumn(
                name: "ValorSueldoOJornal",
                table: "Acuerdos",
                newName: "ValorBlanco");
        }
    }
}
