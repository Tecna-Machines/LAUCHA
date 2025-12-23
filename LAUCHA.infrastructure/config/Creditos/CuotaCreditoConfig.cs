namespace LAUCHA.infrastructure.config.Creditos
{
    internal class CuotaCreditoConfig : IEntityTypeConfiguration<CuotaCredito>
    {
        public void Configure(EntityTypeBuilder<CuotaCredito> builder)
        {
            builder.HasKey(cc => new { cc.Nro, cc.CodigoCredito });

            builder.Property(cc => cc.CodigoCredito).IsRequired();
            builder.Property(cc => cc.Nro).IsRequired();

            builder.HasOne<Credito>()
                  .WithMany(c => c.Cuotas)
                  .HasForeignKey(cc => cc.CodigoCredito)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<ItemLiquidacion>()
             .WithMany()
             .HasForeignKey(cc => new { cc.CodigoLiquidacion, cc.NroItem })
             .IsRequired(false)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
