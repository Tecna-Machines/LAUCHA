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
    internal class LiquidacionConfig : IEntityTypeConfiguration<Liquidacion>
    {
        public void Configure(EntityTypeBuilder<Liquidacion> builder)
        {
            builder.HasKey(liquidacion => liquidacion.CodigoLiquidacion);

        }
    }
}
