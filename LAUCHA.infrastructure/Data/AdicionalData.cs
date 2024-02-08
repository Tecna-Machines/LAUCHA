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
    internal class AdicionalData : IEntityTypeConfiguration<Adicional>
    {
        public void Configure(EntityTypeBuilder<Adicional> builder)
        {
            builder.HasData(
                    new Adicional
                    {
                        CodigoAdicional = "3040",
                        Concepto = "Adicional Titulo Universitario",
                        EsPorcentual = true,
                        Unidades = 2
                    },
                    new Adicional
                    {
                        CodigoAdicional = "3050",
                        Concepto = "Adicional viaticos",
                        EsPorcentual = false,
                        Unidades = 2000
                    },
                    new Adicional
                    {
                        CodigoAdicional = "3060",
                        Concepto = "Adicional por trabajo riesgoso",
                        EsPorcentual = false,
                        Unidades = 10000
                    },
                    new Adicional
                    {
                        CodigoAdicional = "3070",
                        Concepto = "Adicional Extra Plus",
                        EsPorcentual = false,
                        Unidades = 90000
                    }
                );
        }
    }
}
