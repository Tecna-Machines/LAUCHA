using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class NoRemuneracionPorLiquidacionConfig : IEntityTypeConfiguration<NoRemuneracionPorLiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<NoRemuneracionPorLiquidacionPersonal> builder)
        {
            builder.HasKey(NoRemuPorLiquidacion =>
                           new { NoRemuPorLiquidacion.CodigoNoRemuneracion, NoRemuPorLiquidacion.CodigoLiquidacionPersonal });

            builder.HasOne(NoRemuPorLiq => NoRemuPorLiq.LiquidacionPersonal)
                   .WithMany(liq => liq.NoRemuneracionesPorLiquidaciones)
                   .HasForeignKey(NoRemuPorLiq => NoRemuPorLiq.CodigoLiquidacionPersonal);

            builder.HasOne(NoRemuPorLiq => NoRemuPorLiq.NoRemuneracion)
                    .WithMany(NoRemu => NoRemu.NoRemuneracionesPorLiquidaciones)
                    .HasForeignKey(NoRemuPorLiq => NoRemuPorLiq.CodigoNoRemuneracion);
        }
    }
}
