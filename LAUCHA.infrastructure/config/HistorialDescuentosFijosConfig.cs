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
    internal class HistorialDescuentosFijosConfig : IEntityTypeConfiguration<HistorialDescuentoFijo>
    {
        public void Configure(EntityTypeBuilder<HistorialDescuentoFijo> builder)
        {
            builder.HasKey(historialDescuentoFijo => new { historialDescuentoFijo.CodigoDescuento, historialDescuentoFijo.FechaFinVigencia});

            builder.HasOne(historialDescuentoFijo => historialDescuentoFijo.DescuentoFijo)
                .WithMany(descuentoFijo => descuentoFijo.HistorialDescuentoFijos)
                .HasForeignKey(historialDescuentoFijo => historialDescuentoFijo.CodigoDescuento);
        }
    }
}
