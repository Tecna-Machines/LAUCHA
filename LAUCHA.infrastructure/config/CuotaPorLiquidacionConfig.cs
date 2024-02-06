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
    internal class CuotaPorLiquidacionConfig : IEntityTypeConfiguration<CuotaPorLiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<CuotaPorLiquidacionPersonal> builder)
        {
            builder.HasKey(cuotaPorLiq =>
                           new { cuotaPorLiq.CodigoCuota, cuotaPorLiq.CodigoLiquidacion });

            builder.HasOne(cuotaPorLiq => cuotaPorLiq.Cuota)
                    .WithMany(cuota => cuota.CuotasPorLiquidaciones)
                    .HasForeignKey(cuotaPorLiq => cuotaPorLiq.CodigoCuota);


            builder.HasOne(cuotaPorLiq => cuotaPorLiq.LiquidacionPersonal)
                    .WithMany(liq => liq.CuotasPorLiquidaciones)
                    .HasForeignKey(cuotaPorLiq => cuotaPorLiq.CodigoLiquidacion);
        }
    }
}
