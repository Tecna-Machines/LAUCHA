using LAUCHA.domain.Entities.Liquidaciones;

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

            builder.HasOne(liqPersonal => liqPersonal.Acuerdo)
                   .WithMany()
                   .HasForeignKey(liqPersonal => liqPersonal.CodigoAcuerdo);
        }
    }
}
