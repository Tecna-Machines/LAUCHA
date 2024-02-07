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
    internal class LiquidacionConfig : IEntityTypeConfiguration<LiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<LiquidacionPersonal> builder)
        {
            builder.HasKey(liquidacion => liquidacion.CodigoLiquidacion);

            builder.HasOne(liqPersonal => liqPersonal.LiquidacionGeneral)
                    .WithMany(liqGeneral => liqGeneral.LiquidacionesPersonales)
                    .HasForeignKey(liqPersonal => liqPersonal.CodigoLiquidacionGeneral);
        }
    }
}
