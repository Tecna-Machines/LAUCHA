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
    internal class TransaccionConfig : IEntityTypeConfiguration<Transaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.HasKey(transaccion => transaccion.NumeroTransaccion);

            builder.HasOne(transaccion => transaccion.Cuenta)
                .WithMany(cuenta => cuenta.Transacciones)
                .HasForeignKey(transaccion => transaccion.NumeroCuenta);
        }
    }
}
