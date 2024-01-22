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
    internal class SubcuotaConfig : IEntityTypeConfiguration<Subcuota>
    {
        public void Configure(EntityTypeBuilder<Subcuota> builder)
        {
            builder.HasKey(subcuota => subcuota.CodigoSubcuota);

            builder.HasOne(subcuota => subcuota.Cuota)
                .WithMany(cuota => cuota.Subcuotas)
                .HasForeignKey(subcuota => subcuota.CodigoCuota);
        }
    }
}
