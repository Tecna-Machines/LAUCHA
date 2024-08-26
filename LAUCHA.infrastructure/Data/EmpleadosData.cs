using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.Data
{
    internal class EmpleadosData : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasData(

                new Empleado
                {
                    Nombre = "Mario",
                    Apellido = "Guitierrez",
                    FechaIngreso = new DateTime(1995, 10, 1),
                    FechaNacimiento = new DateTime(1940, 10, 2),
                    Dni = "11584752"
                },

                new Empleado
                {
                    Nombre = "Pedro",
                    Apellido = "Pascal",
                    FechaIngreso = new DateTime(2020, 9, 1),
                    FechaNacimiento = new DateTime(1940, 10, 2),
                    Dni = "13584780"
                },
                new Empleado
                {
                    Nombre = "Maria",
                    Apellido = "Lopez",
                    FechaIngreso = new DateTime(2002, 8, 11),
                    FechaNacimiento = new DateTime(1970, 10, 2),
                    Dni = "14784252"
                }

                );
        }
    }
}
