using LAUCHA.domain.Entities.Acuerdos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class AcuerdoBlancoConfig : IEntityTypeConfiguration<AcuerdoBlanco>
    {
        public void Configure(EntityTypeBuilder<AcuerdoBlanco> builder)
        {
            builder.HasKey(acuerdoBlanco => acuerdoBlanco.CodigoAcuerdoBlanco);
        }
    }
}
