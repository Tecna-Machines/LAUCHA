namespace LAUCHA.infrastructure.config
{
    internal class RetencionConfig : IEntityTypeConfiguration<RetencionOLD>
    {
        public void Configure(EntityTypeBuilder<RetencionOLD> builder)
        {
            builder.HasKey(retencion => retencion.CodigoRetencion);

            builder.HasOne(retencion => retencion.Cuenta)
                    .WithMany(cuenta => cuenta.Retenciones)
                    .HasForeignKey(retencion => retencion.NumeroCuenta);
        }
    }
}
