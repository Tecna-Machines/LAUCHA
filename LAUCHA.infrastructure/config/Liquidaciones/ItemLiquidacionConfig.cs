namespace LAUCHA.infrastructure.Config.Liquidaciones
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
