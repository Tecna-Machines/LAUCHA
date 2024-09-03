using LAUCHA.domain.entities.diasEspeciales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class AvisosAusenciaConfig : IEntityTypeConfiguration<AvisosAusencia>
    {
        public void Configure(EntityTypeBuilder<AvisosAusencia> builder)
        {
            builder.HasKey(aa => new { aa.DniEmpleado, aa.FechaAusencia });

            builder.HasOne(aa => aa.Empleado)
                    .WithMany(emp => emp.Ausencias)
                     .HasForeignKey(emp => emp.DniEmpleado);

            builder.Property(aa => aa.Motivo).HasMaxLength(120);
        }
    }
}
