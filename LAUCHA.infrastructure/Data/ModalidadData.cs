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
    internal class ModalidadData : IEntityTypeConfiguration<Modalidad>
    {
        public void Configure(EntityTypeBuilder<Modalidad> builder)
        {
            builder.HasData(
                    new Modalidad
                    {
                        CodigoModalidad = "10",
                        Descripcion = "mensual fijo"
                    },
                    new Modalidad
                    {
                        CodigoModalidad = "20",
                        Descripcion = "quincena por hora"
                    },
                    new Modalidad
                    {
                        CodigoModalidad = "22",
                        Descripcion = "quincenal fijo"
                    },
                    new Modalidad
                    {
                        CodigoModalidad = "12",
                        Descripcion = "mensual fijo + horas extras"
                    }
                );
        }
    }
}
