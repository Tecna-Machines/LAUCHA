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
    internal class CuentaConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(cuenta => cuenta.NumeroCuenta);

            builder.HasOne(cuenta => cuenta.Empleado)
                .WithOne(empleado => empleado.Cuenta)
                .HasForeignKey<Cuenta>(cuenta => cuenta.DniEmpleado);
        }
    }
}
