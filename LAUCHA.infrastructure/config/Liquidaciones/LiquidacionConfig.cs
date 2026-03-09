namespace LAUCHA.infrastructure.Config.Liquidaciones
{
    internal class LiquidacionConfig : IEntityTypeConfiguration<Liquidacion>
    {
        public void Configure(EntityTypeBuilder<Liquidacion> builder)
        {
            builder.HasKey(liquidacion => liquidacion.Codigo);


            builder.HasOne(liqPersonal => liqPersonal.Acuerdo)
                   .WithMany()
                   .HasForeignKey(liqPersonal => liqPersonal.CodigoAcuerdo);

            builder.HasMany(l => l.Pagos)
                        .WithOne()
                        .HasForeignKey(p => p.LiquidacionId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
