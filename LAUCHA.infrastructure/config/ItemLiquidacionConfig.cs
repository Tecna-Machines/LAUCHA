using LAUCHA.domain.Entities.Liquidaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class ItemLiquidacionConfig : IEntityTypeConfiguration<ItemLiquidacion>
    {
        public void Configure(EntityTypeBuilder<ItemLiquidacion> builder)
        {
            builder.HasKey(il => new { il.CodigoLiquidacion, il.NroItem });

            builder
           .HasOne<Liquidacion>()
           .WithMany(l => l.Items)
           .HasForeignKey(il => il.CodigoLiquidacion)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
