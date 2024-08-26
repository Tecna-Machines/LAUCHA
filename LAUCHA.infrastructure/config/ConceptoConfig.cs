using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class ConceptoConfig : IEntityTypeConfiguration<Concepto>
    {
        public void Configure(EntityTypeBuilder<Concepto> builder)
        {
            builder.HasKey(concepto => concepto.NumeroConcepto);
        }
    }
}
