namespace LAUCHA.infrastructure.config
{
    internal class RetencionFijaConfig : IEntityTypeConfiguration<CatalogoRetencion>
    {
        public void Configure(EntityTypeBuilder<CatalogoRetencion> builder)
        {
            builder.HasKey(retencionFija => retencionFija.Codigo);

        }
    }
}
