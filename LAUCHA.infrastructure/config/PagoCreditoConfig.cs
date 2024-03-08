using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class PagoCreditoConfig : IEntityTypeConfiguration<PagoCredito>
    {
        public void Configure(EntityTypeBuilder<PagoCredito> builder)
        {
            builder.HasKey(pagoCredito => new { pagoCredito.CodigoCredito, pagoCredito.CodigoDescuento });

            builder.HasOne(pagoCredito => pagoCredito.Credito)
                    .WithMany(credito => credito.PagosCreditos)
                    .HasForeignKey(pagoCredito => pagoCredito.CodigoCredito);

            builder.HasOne(pagoCredito => pagoCredito.Descuento)
                    .WithMany(descuento => descuento.PagosCreditos)
                    .HasForeignKey(pagoCredito => pagoCredito.CodigoDescuento);
        }
    }
}
