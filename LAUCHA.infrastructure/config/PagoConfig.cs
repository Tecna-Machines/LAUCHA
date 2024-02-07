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
    internal class PagoConfig : IEntityTypeConfiguration<PagoLiquidacion>
    {
        public void Configure(EntityTypeBuilder<PagoLiquidacion> builder)
        {
            builder.HasKey(pago => pago.CodigoPago);

            builder.HasOne(pago => pago.Liquidacion)
                    .WithMany(liquidacion => liquidacion.PagosLiquidacion)
                    .HasForeignKey(pago => pago.CodigoLiquidacion);
        }
    }
}
