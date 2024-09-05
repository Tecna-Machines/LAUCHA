using LAUCHA.domain.entities.diasEspeciales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class PeriodoVacacionesConfig : IEntityTypeConfiguration<PeriodoVacaciones>
    {
        public void Configure(EntityTypeBuilder<PeriodoVacaciones> builder)
        {
            builder.HasKey(pv => new { pv.DniEmpleado, pv.FechaInicio });

            builder.HasOne(pv => pv.Empleado)
                    .WithMany(emp => emp.PeriodosVacaciones)
                    .HasForeignKey(pv => pv.DniEmpleado)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
