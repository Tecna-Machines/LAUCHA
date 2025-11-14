using LAUCHA.domain.Entities.Liquidacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class LiquidacionConfig : IEntityTypeConfiguration<Liquidacion>
    {
        public void Configure(EntityTypeBuilder<Liquidacion> builder)
        {
            builder.HasKey(liquidacion => liquidacion.Codigo);

            builder.HasOne(liqPersonal => liqPersonal.LiquidacionGeneral)
                    .WithMany(liqGeneral => liqGeneral.LiquidacionesPersonales)
                    .HasForeignKey(liqPersonal => liqPersonal.CodigoLiquidacionGeneral);

            builder.HasOne(liqPersonal => liqPersonal.Contrato)
                   .WithMany()
                   .HasForeignKey(liqPersonal => liqPersonal.CodigoAcuerdo);
        }
    }
}
