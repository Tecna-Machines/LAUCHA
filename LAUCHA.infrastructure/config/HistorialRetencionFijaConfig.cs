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
    internal class HistorialRetencionFijaConfig : IEntityTypeConfiguration<HistorialRetencionFija>
    {
        public void Configure(EntityTypeBuilder<HistorialRetencionFija> builder)
        {
            builder.HasKey(historialRetencionFija => 
                           new { historialRetencionFija.CodigoRetencionFija, historialRetencionFija.FechaFinVigencia });

            builder.HasOne(historialRetencionFija => historialRetencionFija.RetencionFija)
                   .WithMany(retencionFija => retencionFija.HistorialRetencionesFijas)
                   .HasForeignKey(retencionFija => retencionFija.CodigoRetencionFija);
        }
    }
}
