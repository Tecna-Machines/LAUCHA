using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class LiquidacionGeneralConfig : IEntityTypeConfiguration<LiquidacionGeneral>
    {
        public void Configure(EntityTypeBuilder<LiquidacionGeneral> builder)
        {
            builder.HasKey(liqGen => liqGen.CodigoLiquidacionGeneral);
        }
    }
}
