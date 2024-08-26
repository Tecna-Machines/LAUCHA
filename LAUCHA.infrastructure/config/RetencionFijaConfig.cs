using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class RetencionFijaConfig : IEntityTypeConfiguration<RetencionFija>
    {
        public void Configure(EntityTypeBuilder<RetencionFija> builder)
        {
            builder.HasKey(retencionFija => retencionFija.CodigoRetencionFija);

        }
    }
}
