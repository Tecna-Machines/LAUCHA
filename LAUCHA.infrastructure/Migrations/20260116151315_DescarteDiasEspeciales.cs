using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DescarteDiasEspeciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvisosAusencia");

            migrationBuilder.DropTable(
                name: "DiasFeriados");

            migrationBuilder.DropTable(
                name: "HabilitacionHorasExtra");

            migrationBuilder.DropTable(
                name: "PeriodoVacaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvisosAusencia",
                columns: table => new
                {
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAusencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCreacionAviso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvisosAusencia", x => new { x.DniEmpleado, x.FechaAusencia });
                    table.ForeignKey(
                        name: "FK_AvisosAusencia_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiasFeriados",
                columns: table => new
                {
                    FechaFeriado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasFeriados", x => x.FechaFeriado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HabilitacionHorasExtra",
                columns: table => new
                {
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DniResponsable = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilitacionHorasExtra", x => new { x.DniEmpleado, x.FechaInicio });
                    table.ForeignKey(
                        name: "FK_HabilitacionHorasExtra_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HabilitacionHorasExtra_Empleados_DniResponsable",
                        column: x => x.DniResponsable,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PeriodoVacaciones",
                columns: table => new
                {
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoVacaciones", x => new { x.DniEmpleado, x.FechaInicio });
                    table.ForeignKey(
                        name: "FK_PeriodoVacaciones_Empleados_DniEmpleado",
                        column: x => x.DniEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HabilitacionHorasExtra_DniResponsable",
                table: "HabilitacionHorasExtra",
                column: "DniResponsable");
        }
    }
}
