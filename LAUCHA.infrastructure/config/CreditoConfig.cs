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
    internal class CreditoConfig : IEntityTypeConfiguration<Credito>
    {
        public void Configure(EntityTypeBuilder<Credito> builder)
        {
            builder.HasKey(credito => credito.CodigoCredito);

            builder.HasOne(credito => credito.Cuenta)
                .WithMany(cuenta => cuenta.Creditos)
                .HasForeignKey(credito => credito.NumeroCuenta);
        }
    }
}
