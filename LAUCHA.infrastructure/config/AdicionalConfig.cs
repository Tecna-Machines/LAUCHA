using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class AdicionalConfig : IEntityTypeConfiguration<Adicional>
    {
        public void Configure(EntityTypeBuilder<Adicional> builder)
        {
            builder.HasKey(adi => adi.CodigoAdicional);
        }
    }
}
