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
    internal class LiquidacionPorTransaccionConfig : IEntityTypeConfiguration<LiquidacionPorTransaccion>
    {
        public void Configure(EntityTypeBuilder<LiquidacionPorTransaccion> builder)
        {
            builder.HasKey(liquidacionPorTrasaccion => new
            {
                liquidacionPorTrasaccion.NumeroTransaccion,
                liquidacionPorTrasaccion.CodigoLiquidacion
            });

            builder.HasOne(liquidacionPorTransaccion => liquidacionPorTransaccion.Transaccion)
                .WithMany(transaccion => transaccion.LiquidacionPorTransaccion)
                .HasForeignKey(liquidacionPorTransaccion => liquidacionPorTransaccion.NumeroTransaccion);

            builder.HasOne(liquidacionPorTransaccion => liquidacionPorTransaccion.Liquidacion)
                .WithMany(liquidacion => liquidacion.LiquidacionPorTransaccion)
                .HasForeignKey(liquidacionPorTransaccion => liquidacionPorTransaccion.CodigoLiquidacion);
        }
    }
}
