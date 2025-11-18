using LAUCHA.domain.Entities.RetencionesCatalogo;

namespace LAUCHA.infrastructure.config
{
    internal class RetencionFijaConfig : IEntityTypeConfiguration<RetencionCatalogo>
    {
        public void Configure(EntityTypeBuilder<RetencionCatalogo> builder)
        {
            builder.HasKey(retencionFija => retencionFija.Codigo);

        }
    }
}
