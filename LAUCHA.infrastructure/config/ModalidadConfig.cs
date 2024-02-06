using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.config
{
    internal class ModalidadConfig : IEntityTypeConfiguration<Modalidad>
    {
        public void Configure(EntityTypeBuilder<Modalidad> builder)
        {
            builder.HasKey(mod => mod.CodigoModalidad);
        }
    }
}
