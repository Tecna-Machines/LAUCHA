using LAUCHA.domain.Entities.Acuerdos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class AcuerdoConfig : IEntityTypeConfiguration<Acuerdo>
    {
        public void Configure(EntityTypeBuilder<Acuerdo> builder)
        {
            builder.ToTable("Acuerdos");
            builder.HasKey(contrato => contrato.Codigo);

            builder.HasOne(contrato => contrato.Empleado)
                .WithMany(empleado => empleado.Contratos)
                .HasForeignKey(contrato => contrato.DniEmpleado);

            builder.HasMany(ct => ct.Adicionales)
                    .WithOne()
                    .HasForeignKey(ad => ad.CodigoContrato);

            builder.Property(a => a.Sueldo).HasColumnType("decimal(18,2)");
            builder.Property(a => a.ValorHora).HasColumnType("decimal(18,2)");
            builder.Property(a => a.ValorBlanco).HasColumnType("decimal(18,2)");
        }
    }
}
