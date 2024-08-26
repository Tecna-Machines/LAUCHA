﻿using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class ContratoConfig : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(contrato => contrato.CodigoContrato);

            builder.HasOne(contrato => contrato.Empleado)
                .WithMany(empleado => empleado.Contratos)
                .HasForeignKey(contrato => contrato.DniEmpleado);

            builder.HasOne(contrato => contrato.AcuerdoBlanco)
                    .WithOne(acuerdoBlanco => acuerdoBlanco.Contrato)
                    .HasForeignKey<AcuerdoBlanco>(acuerdoBlanco => acuerdoBlanco.CodigoContrato);
        }
    }
}
