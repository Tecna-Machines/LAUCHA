﻿using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.config
{
    internal class RetencionFijaConfig : IEntityTypeConfiguration<RetencionFija>
    {
        public void Configure(EntityTypeBuilder<RetencionFija> builder)
        {
            builder.HasKey(retencionFija => retencionFija.CodigoRetencionFija);

        }
    }
}
