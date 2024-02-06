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
    internal class SubcuotaPorLiquidacionConfig : IEntityTypeConfiguration<SubCuotaPorLiquidacion>
    {
        public void Configure(EntityTypeBuilder<SubCuotaPorLiquidacion> builder)
        {
            builder.HasKey(subCuotPorLiq =>
                           new { subCuotPorLiq.CodigoSubcuota, subCuotPorLiq.CodigoLiquidacion });

            builder.HasOne(subCuotPorLiq => subCuotPorLiq.Subcuota)
                    .WithMany(subcuota => subcuota.SubCuotasPorLiquidaciones)
                    .HasForeignKey(subCuotPorLiq => subCuotPorLiq.CodigoLiquidacion);


            builder.HasOne(subCuotPorLiq => subCuotPorLiq.LiquidacionPersonal)
                    .WithMany(liq => liq.SubCuotasPorLiquidaciones)
                    .HasForeignKey(subCuotPorLiq => subCuotPorLiq.CodigoLiquidacion);
        }
    }
}
