using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ItemsLiquidacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoContrato",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "TotalDescuentos",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "TotalNoRemunerativo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "TotalRetenciones",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "TotalSueldo",
                table: "LiquidacionesPersonales");

            migrationBuilder.RenameColumn(
                name: "CodigoContrato",
                table: "LiquidacionesPersonales",
                newName: "CodigoAcuerdo");

            migrationBuilder.RenameColumn(
                name: "CodigoLiquidacion",
                table: "LiquidacionesPersonales",
                newName: "Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_LiquidacionesPersonales_CodigoContrato",
                table: "LiquidacionesPersonales",
                newName: "IX_LiquidacionesPersonales_CodigoAcuerdo");

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "LiquidacionesPersonales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DniEmpleado",
                table: "LiquidacionesPersonales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "LiquidacionesPersonales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "LiquidacionesPersonales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSello",
                table: "LiquidacionesPersonales",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "LiquidacionesPersonales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quincena",
                table: "LiquidacionesPersonales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemLiquidacion",
                columns: table => new
                {
                    NroItem = table.Column<int>(type: "int", nullable: false),
                    CodigoLiquidacion = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Concepto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EsEnBlanco = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsIncremento = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLiquidacion", x => new { x.CodigoLiquidacion, x.NroItem });
                    table.ForeignKey(
                        name: "FK_ItemLiquidacion_LiquidacionesPersonales_CodigoLiquidacion",
                        column: x => x.CodigoLiquidacion,
                        principalTable: "LiquidacionesPersonales",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoAcuerdo",
                table: "LiquidacionesPersonales",
                column: "CodigoAcuerdo",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoAcuerdo",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropTable(
                name: "ItemLiquidacion");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "DniEmpleado",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "FechaSello",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "LiquidacionesPersonales");

            migrationBuilder.DropColumn(
                name: "Quincena",
                table: "LiquidacionesPersonales");

            migrationBuilder.RenameColumn(
                name: "CodigoAcuerdo",
                table: "LiquidacionesPersonales",
                newName: "CodigoContrato");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "LiquidacionesPersonales",
                newName: "CodigoLiquidacion");

            migrationBuilder.RenameIndex(
                name: "IX_LiquidacionesPersonales_CodigoAcuerdo",
                table: "LiquidacionesPersonales",
                newName: "IX_LiquidacionesPersonales_CodigoContrato");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDescuentos",
                table: "LiquidacionesPersonales",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalNoRemunerativo",
                table: "LiquidacionesPersonales",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRetenciones",
                table: "LiquidacionesPersonales",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSueldo",
                table: "LiquidacionesPersonales",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_LiquidacionesPersonales_Acuerdos_CodigoContrato",
                table: "LiquidacionesPersonales",
                column: "CodigoContrato",
                principalTable: "Acuerdos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
