using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.Data
{
    internal class CuentaData : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasData(
                    new Cuenta
                    {
                        DniEmpleado = "11584752",
                        FechaCreacion = DateTime.Now,
                        estadoCuenta = true,
                        NumeroCuenta = "1158475225"
                    },
                    new Cuenta
                    {
                        DniEmpleado = "13584780",
                        FechaCreacion = DateTime.Now,
                        estadoCuenta = true,
                        NumeroCuenta = "1358478025"
                    },
                    new Cuenta
                    {
                        DniEmpleado = "14784252",
                        FechaCreacion = DateTime.Now,
                        estadoCuenta = true,
                        NumeroCuenta = "1478425225"
                    }

                );
        }
    }
}
