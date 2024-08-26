using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class DescuentoConfig : IEntityTypeConfiguration<Descuento>
    {
        public void Configure(EntityTypeBuilder<Descuento> builder)
        {
            builder.HasKey(descuento => descuento.CodigoDescuento);

            builder.HasOne(descuento => descuento.Concepto)
                .WithMany(concepto => concepto.Descuentos)
                .HasForeignKey(descuento => descuento.NumeroConcepto);

            builder.HasOne(descuento => descuento.Cuenta)
                    .WithMany(cuenta => cuenta.Descuentos)
                    .HasForeignKey(descuento => descuento.NumeroCuenta);

            builder.HasMany(descuento => descuento.PagosCreditos)
                    .WithOne(pagoCredito => pagoCredito.Descuento)
                    .HasForeignKey(pagoCredito => pagoCredito.CodigoDescuento);
        }
    }
}
