using LAUCHA.domain.entities;

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
