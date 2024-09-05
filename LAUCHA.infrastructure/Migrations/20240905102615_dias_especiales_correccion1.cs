using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dias_especiales_correccion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodoVacaciones_Empleados_EmpleadoDni",
                table: "PeriodoVacaciones");

            migrationBuilder.DropIndex(
                name: "IX_PeriodoVacaciones_EmpleadoDni",
                table: "PeriodoVacaciones");

            migrationBuilder.DropColumn(
                name: "EmpleadoDni",
                table: "PeriodoVacaciones");

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1158475225",
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 5, 7, 26, 15, 278, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1358478025",
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 5, 7, 26, 15, 278, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1478425225",
                column: "FechaCreacion",
                value: new DateTime(2024, 9, 5, 7, 26, 15, 278, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodoVacaciones_Empleados_DniEmpleado",
                table: "PeriodoVacaciones",
                column: "DniEmpleado",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodoVacaciones_Empleados_DniEmpleado",
                table: "PeriodoVacaciones");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoDni",
                table: "PeriodoVacaciones",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_PeriodoVacaciones_EmpleadoDni",
                table: "PeriodoVacaciones",
                column: "EmpleadoDni");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodoVacaciones_Empleados_EmpleadoDni",
                table: "PeriodoVacaciones",
                column: "EmpleadoDni",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
