using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class AcuerdoConfig : IEntityTypeConfiguration<Acuerdo>
    {
        public void Configure(EntityTypeBuilder<Acuerdo> builder)
        {
            builder.ToTable("Acuerdos");
            builder.HasKey(a => a.Codigo);

            builder.Property(a => a.DniEmpleado)
                    .HasColumnName("DniEmpleado")
                    .IsRequired();

            builder.HasOne(a => a.Empleado)
                .WithMany(e => e.Contratos)
                .HasForeignKey(a => a.DniEmpleado)
                .HasPrincipalKey(e => e.Dni)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Acuerdos_Empleados_DniEmpleado");

            builder.HasMany(a => a.Adicionales)
                    .WithOne()
                    .HasForeignKey(ad => ad.CodigoContrato);

            builder.Property(a => a.Sueldo).HasColumnType("decimal(18,2)");
            builder.Property(a => a.ValorHora).HasColumnType("decimal(18,2)");
            builder.Property(a => a.ValorBlanco).HasColumnType("decimal(18,2)");
        }
    }
}
