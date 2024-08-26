using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class RetencionesFijasPorCuentaConfig : IEntityTypeConfiguration<RetencionFijaPorCuenta>
    {
        public void Configure(EntityTypeBuilder<RetencionFijaPorCuenta> builder)
        {
            builder.HasKey(retencioneFijaPorCuenta =>
                           new { retencioneFijaPorCuenta.NumeroCuenta, retencioneFijaPorCuenta.CodigoRetencionFija });

            builder.HasOne(retencionesFijaPorCuenta => retencionesFijaPorCuenta.Cuenta)
                    .WithMany(cuenta => cuenta.RetencionesFijasPorCuenta)
                    .HasForeignKey(retencionesFijasPorCuenta => retencionesFijasPorCuenta.NumeroCuenta);


            builder.HasOne(retencionesFijaPorCuenta => retencionesFijaPorCuenta.RetencionFija)
                    .WithMany(retencionFija => retencionFija.RetencionesFijasPorCuenta)
                    .HasForeignKey(retencionesFijasPorCuenta => retencionesFijasPorCuenta.CodigoRetencionFija);
        }
    }
}
