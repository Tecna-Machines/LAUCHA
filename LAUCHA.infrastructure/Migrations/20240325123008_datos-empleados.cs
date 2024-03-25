using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAUCHA.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class datosempleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Dni", "Apellido", "FechaIngreso", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { "11584752", "Guitierrez", new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1940, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario" },
                    { "13584780", "Pascal", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1940, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" },
                    { "14784252", "Lopez", new DateTime(2002, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "NumeroCuenta", "DniEmpleado", "FechaCreacion", "estadoCuenta" },
                values: new object[,]
                {
                    { "1158475225", "11584752", new DateTime(2024, 3, 25, 9, 30, 8, 768, DateTimeKind.Local).AddTicks(5782), true },
                    { "1358478025", "13584780", new DateTime(2024, 3, 25, 9, 30, 8, 768, DateTimeKind.Local).AddTicks(5792), true },
                    { "1478425225", "14784252", new DateTime(2024, 3, 25, 9, 30, 8, 768, DateTimeKind.Local).AddTicks(5793), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1158475225");

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1358478025");

            migrationBuilder.DeleteData(
                table: "Cuentas",
                keyColumn: "NumeroCuenta",
                keyValue: "1478425225");

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Dni",
                keyValue: "11584752");

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Dni",
                keyValue: "13584780");

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "Dni",
                keyValue: "14784252");
        }
    }
}
