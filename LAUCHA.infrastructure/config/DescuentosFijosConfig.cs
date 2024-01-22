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
    internal class DescuentosFijosConfig : IEntityTypeConfiguration<DescuentoFijo>
    {
        public void Configure(EntityTypeBuilder<DescuentoFijo> builder)
        {
            builder.HasKey(descuentoFijo => descuentoFijo.CodigoDescuento);
        }
    }
}
