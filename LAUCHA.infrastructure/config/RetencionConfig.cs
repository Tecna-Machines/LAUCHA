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
    internal class RetencionConfig : IEntityTypeConfiguration<Retencion>
    {
        public void Configure(EntityTypeBuilder<Retencion> builder)
        {
            builder.HasKey(retencion => retencion.CodigoRetencion);

            builder.HasOne(retencion => retencion.Cuenta)
                    .WithMany(cuenta => cuenta.Retenciones)
                    .HasForeignKey(retencion => retencion.NumeroCuenta);
        }
    }
}
