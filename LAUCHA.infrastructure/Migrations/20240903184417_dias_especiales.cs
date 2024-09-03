using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dias_especiales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvisosAusencia",
                columns: table => new
                {
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaAusencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    FechaCreacionAviso = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiasFeriados",
                columns: table => new
                {
                    FechaFeriado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasFeriados", x => x.FechaFeriado);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HabilitacionHorasExtra",
                columns: table => new
                {
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DniResponsable = table.Column<string>(type: "varchar(255)", nullable: false),
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
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PeriodoVacaciones",
                columns: table => new
                {
                    DniEmpleado = table.Column<string>(type: "varchar(255)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacion = table.Column<string>(type: "longtext", nullable: false),
                    EmpleadoDni = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoVacaciones", x => new { x.DniEmpleado, x.FechaInicio });
                    table.ForeignKey(
                        name: "FK_PeriodoVacaciones_Empleados_EmpleadoDni",
                        column: x => x.EmpleadoDni,
                        principalTable: "Empleados",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1158475225",
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 3, 15, 44, 17, 717, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1358478025",
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 3, 15, 44, 17, 717, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1478425225",
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 3, 15, 44, 17, 717, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.CreateIndex(
                name: "IX_HabilitacionHorasExtra_DniResponsable",
                table: "HabilitacionHorasExtra",
                column: "DniResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoVacaciones_EmpleadoDni",
                table: "PeriodoVacaciones",
                column: "EmpleadoDni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvisosAusencia");

            migrationBuilder.DropTable(
                name: "DiasFeriados");

            migrationBuilder.DropTable(
                name: "HabilitacionHorasExtra");

            migrationBuilder.DropTable(
                name: "PeriodoVacaciones");

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1158475225",
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 25, 9, 30, 8, 768, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1358478025",
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 25, 9, 30, 8, 768, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1478425225",
                column: "FechaCreacion",
                value: new DateTime(2024, 3, 25, 9, 30, 8, 768, DateTimeKind.Local).AddTicks(5793));
        }
    }
}
