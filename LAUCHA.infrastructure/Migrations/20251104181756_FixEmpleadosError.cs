using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixEmpleadosError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acuerdos_Empleados_DniEmpleado",
                table: "Acuerdos");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoDni",
                table: "Acuerdos",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Acuerdos_EmpleadoDni",
                table: "Acuerdos",
                column: "EmpleadoDni");

            migrationBuilder.AddForeignKey(
                name: "FK_Acuerdos_Empleados_DniEmpleado",
                table: "Acuerdos",
                column: "DniEmpleado",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acuerdos_Empleados_EmpleadoDni",
                table: "Acuerdos",
                column: "EmpleadoDni",
                principalTable: "Empleados",
                principalColumn: "Dni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acuerdos_Empleados_DniEmpleado",
                table: "Acuerdos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acuerdos_Empleados_EmpleadoDni",
                table: "Acuerdos");

            migrationBuilder.DropIndex(
                name: "IX_Acuerdos_EmpleadoDni",
                table: "Acuerdos");

            migrationBuilder.DropColumn(
                name: "EmpleadoDni",
                table: "Acuerdos");

            migrationBuilder.AddForeignKey(
                name: "FK_Acuerdos_Empleados_DniEmpleado",
                table: "Acuerdos",
                column: "DniEmpleado",
                principalTable: "Empleados",
                principalColumn: "Dni",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
