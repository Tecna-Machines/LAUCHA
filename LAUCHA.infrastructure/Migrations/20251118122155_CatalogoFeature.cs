using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CatalogoFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetencionAcuerdo_RetencionCatalogo_CodigoRetencion",
                table: "RetencionAcuerdo");

            migrationBuilder.DropTable(
                name: "RetencionCatalogo");

            migrationBuilder.CreateTable(
                name: "CatalogoRetenciones",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrimeraQuincena = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoRetenciones", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CatalogoRetenciones",
                columns: new[] { "Codigo", "Concepto", "EsPorcentual", "PrimeraQuincena", "Unidades" },
                values: new object[,]
                {
                    { "0900", "Jubilacion", true, false, 11m },
                    { "0905", "Ley 19032", true, false, 3m },
                    { "0910", "Obra Social", true, false, 3m },
                    { "0920", "Aporte Sindical Obligatorio", true, false, 2.5m },
                    { "0940", "Seguro y Sepelio", false, true, 2300m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RetencionAcuerdo_CatalogoRetenciones_CodigoRetencion",
                table: "RetencionAcuerdo",
                column: "CodigoRetencion",
                principalTable: "CatalogoRetenciones",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetencionAcuerdo_CatalogoRetenciones_CodigoRetencion",
                table: "RetencionAcuerdo");

            migrationBuilder.DropTable(
                name: "CatalogoRetenciones");

            migrationBuilder.CreateTable(
                name: "RetencionCatalogo",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EsPorcentual = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PrimeraQuincena = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Unidades = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetencionCatalogo", x => x.Codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "RetencionCatalogo",
                columns: new[] { "Codigo", "Concepto", "EsPorcentual", "PrimeraQuincena", "Unidades" },
                values: new object[,]
                {
                    { "0900", "Jubilacion", true, false, 11m },
                    { "0905", "Ley 19032", true, false, 3m },
                    { "0910", "Obra Social", true, false, 3m },
                    { "0920", "Aporte Sindical Obligatorio", true, false, 2.5m },
                    { "0940", "Seguro y Sepelio", false, true, 2300m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RetencionAcuerdo_RetencionCatalogo_CodigoRetencion",
                table: "RetencionAcuerdo",
                column: "CodigoRetencion",
                principalTable: "RetencionCatalogo",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
