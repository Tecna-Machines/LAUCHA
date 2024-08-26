using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class RemuneracionPorLiquidacionConfig : IEntityTypeConfiguration<RemuneracionPorLiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<RemuneracionPorLiquidacionPersonal> builder)
        {
            builder.HasKey(remuneracionPorLiquidacion =>
                           new { remuneracionPorLiquidacion.CodigoRemuneracion, remuneracionPorLiquidacion.CodigoLiquidacionPersonal });

            builder.HasOne(remuPorLiq => remuPorLiq.Remuneracion)
                    .WithMany(remu => remu.RemuneracionPorLiquidacionPersonales)
                    .HasForeignKey(remuPorLiq => remuPorLiq.CodigoRemuneracion);


            builder.HasOne(remuPorLiq => remuPorLiq.LiquidacionPersonal)
                    .WithMany(liq => liq.RemuneracionPorLiquidacionPersonales)
                    .HasForeignKey(remuPorLiq => remuPorLiq.CodigoLiquidacionPersonal);
        }
    }
}
