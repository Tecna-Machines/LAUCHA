using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.config
{
    internal class DescuentoFijoPorCuentaConfig : IEntityTypeConfiguration<DescuentoFijoPorCuenta>
    {
        public void Configure(EntityTypeBuilder<DescuentoFijoPorCuenta> builder)
        {
            builder.HasKey(descuentoFijoPorCuenta => new 
            { 
                descuentoFijoPorCuenta.NumeroCuenta, 
                descuentoFijoPorCuenta.CodigoDescuento 
            });

            builder.HasOne(descuentoFijoPorCuenta => descuentoFijoPorCuenta.Cuenta)
                .WithMany(cuenta => cuenta.DescuentosFijosPorCuenta)
                .HasForeignKey(descuentoFijoPorCuenta => descuentoFijoPorCuenta.NumeroCuenta);

            builder.HasOne(descuentoFijoPorCuenta => descuentoFijoPorCuenta.DescuentoFijo)
                .WithMany(descuentoFijo => descuentoFijo.DescuentosFijosPorCuenta)
                .HasForeignKey(descuentoFijoPorCuenta => descuentoFijoPorCuenta.CodigoDescuento);
        }
    }
}
