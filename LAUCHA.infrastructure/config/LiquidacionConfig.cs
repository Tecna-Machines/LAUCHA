using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class LiquidacionConfig : IEntityTypeConfiguration<LiquidacionPersonal>
    {
        public void Configure(EntityTypeBuilder<LiquidacionPersonal> builder)
        {
            builder.HasKey(liquidacion => liquidacion.CodigoLiquidacion);

            builder.HasOne(liqPersonal => liqPersonal.LiquidacionGeneral)
                    .WithMany(liqGeneral => liqGeneral.LiquidacionesPersonales)
                    .HasForeignKey(liqPersonal => liqPersonal.CodigoLiquidacionGeneral);

            builder.HasOne(liqPersonal => liqPersonal.Contrato)
                   .WithMany(contrato => contrato.Liquidaciones)
                   .HasForeignKey(liqPersonal => liqPersonal.CodigoContrato);
        }
    }
}
