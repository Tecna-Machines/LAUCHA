using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class ModalidadConfig : IEntityTypeConfiguration<Modalidad>
    {
        public void Configure(EntityTypeBuilder<Modalidad> builder)
        {
            builder.HasKey(mod => mod.CodigoModalidad);
        }
    }
}
