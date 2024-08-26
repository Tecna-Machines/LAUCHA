using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class RetencionConfig : IEntityTypeConfiguration<Retencion>
    {
        public void Configure(EntityTypeBuilder<Retencion> builder)
        {
            builder.HasKey(retencion => retencion.CodigoRetencion);

            builder.HasOne(retencion => retencion.Cuenta)
                    .WithMany(cuenta => cuenta.Retenciones)
                    .HasForeignKey(retencion => retencion.NumeroCuenta);
        }
    }
}
