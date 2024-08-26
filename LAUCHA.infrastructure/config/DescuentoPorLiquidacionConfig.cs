using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class DescuentoPorLiquidacionConfig : IEntityTypeConfiguration<DescuentoPorLiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<DescuentoPorLiquidacionPersonal> builder)
        {
            builder.HasKey(descuenPorLiq =>
                           new { descuenPorLiq.CodigoDescuento, descuenPorLiq.CodigoLiquidacionPersonal });

            builder.HasOne(descuenPorLiq => descuenPorLiq.Descuento)
                    .WithMany(des => des.DescuentoPorLiquidacionPersonales)
                    .HasForeignKey(descuenPorLiq => descuenPorLiq.CodigoDescuento);


            builder.HasOne(descuenPorLiq => descuenPorLiq.LiquidacionPersonal)
                    .WithMany(liq => liq.DescuentoPorLiquidacionPersonales)
                    .HasForeignKey(descuenPorLiq => descuenPorLiq.CodigoLiquidacionPersonal);
        }
    }
}
