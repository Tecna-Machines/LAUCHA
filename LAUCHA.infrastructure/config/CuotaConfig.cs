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
    internal class CuotaConfig : IEntityTypeConfiguration<Cuota>
    {
        public void Configure(EntityTypeBuilder<Cuota> builder)
        {
            builder.HasKey(cuota => cuota.CodigoCuota);

            builder.HasOne(cuota => cuota.Credito)
                .WithMany(credito => credito.Cuotas)
                .HasForeignKey(cuota => cuota.CodigoCredito);
        }
    }
}
