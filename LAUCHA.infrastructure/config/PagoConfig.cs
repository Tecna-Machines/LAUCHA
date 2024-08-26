using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
