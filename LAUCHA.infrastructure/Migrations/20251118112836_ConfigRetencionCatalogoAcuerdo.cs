using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigRetencionCatalogoAcuerdo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicionales_Acuerdos_CodigoContrato",
                table: "Adicionales");

            migrationBuilder.DropForeignKey(
                name: "FK_RetencionAcuerdo_Acuerdos_AcuerdoCodigo",
                table: "RetencionAcuerdo");

            migrationBuilder.DropIndex(
                name: "IX_RetencionAcuerdo_AcuerdoCodigo",
                table: "RetencionAcuerdo");

            migrationBuilder.DropColumn(
                name: "AcuerdoCodigo",
                table: "RetencionAcuerdo");

            migrationBuilder.RenameColumn(
                name: "CodigoContrato",
                table: "Adicionales",
                newName: "CodigoAcuerdo");

            migrationBuilder.RenameIndex(
                name: "IX_Adicionales_CodigoContrato",
                table: "Adicionales",
                newName: "IX_Adicionales_CodigoAcuerdo");

            migrationBuilder.CreateIndex(
                name: "IX_RetencionAcuerdo_CodigoAcuerdo",
                table: "RetencionAcuerdo",
                column: "CodigoAcuerdo");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicionales_Acuerdos_CodigoAcuerdo",
                table: "Adicionales",
                column: "CodigoAcuerdo",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RetencionAcuerdo_Acuerdos_CodigoAcuerdo",
                table: "RetencionAcuerdo",
                column: "CodigoAcuerdo",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicionales_Acuerdos_CodigoAcuerdo",
                table: "Adicionales");

            migrationBuilder.DropForeignKey(
                name: "FK_RetencionAcuerdo_Acuerdos_CodigoAcuerdo",
                table: "RetencionAcuerdo");

            migrationBuilder.DropIndex(
                name: "IX_RetencionAcuerdo_CodigoAcuerdo",
                table: "RetencionAcuerdo");

            migrationBuilder.RenameColumn(
                name: "CodigoAcuerdo",
                table: "Adicionales",
                newName: "CodigoContrato");

            migrationBuilder.RenameIndex(
                name: "IX_Adicionales_CodigoAcuerdo",
                table: "Adicionales",
                newName: "IX_Adicionales_CodigoContrato");

            migrationBuilder.AddColumn<string>(
                name: "AcuerdoCodigo",
                table: "RetencionAcuerdo",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RetencionAcuerdo_AcuerdoCodigo",
                table: "RetencionAcuerdo",
                column: "AcuerdoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicionales_Acuerdos_CodigoContrato",
                table: "Adicionales",
                column: "CodigoContrato",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RetencionAcuerdo_Acuerdos_AcuerdoCodigo",
                table: "RetencionAcuerdo",
                column: "AcuerdoCodigo",
                principalTable: "Acuerdos",
                principalColumn: "Codigo");
        }
    }
}
