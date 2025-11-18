using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigRetencionCatalogoAcuerdoFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_RetencionAcuerdo_RetencionCatalogo_CodigoRetencion",
                table: "RetencionAcuerdo",
                column: "CodigoRetencion",
                principalTable: "RetencionCatalogo",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetencionAcuerdo_RetencionCatalogo_CodigoRetencion",
                table: "RetencionAcuerdo");
        }
    }
}
