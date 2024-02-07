using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
