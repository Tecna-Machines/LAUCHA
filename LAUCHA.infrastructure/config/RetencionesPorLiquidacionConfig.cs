using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class RetencionesPorLiquidacionConfig : IEntityTypeConfiguration<RetencionPorLiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<RetencionPorLiquidacionPersonal> builder)
        {
            builder.HasKey(retenLiq =>
                          new { retenLiq.CodigoRetencion, retenLiq.CodigoLiquidacionPersonal });

            builder.HasOne(retenLiq => retenLiq.Retencion)
                    .WithMany(retencion => retencion.RetencionPorLiquidacionPersonales)
                    .HasForeignKey(retenLiq => retenLiq.CodigoRetencion);


            builder.HasOne(retenLiq => retenLiq.LiquidacionPersonal)
                    .WithMany(liq => liq.RetencionPorLiquidacionPersonales)
                    .HasForeignKey(retenLiq => retenLiq.CodigoLiquidacionPersonal);
        }
    }
}
