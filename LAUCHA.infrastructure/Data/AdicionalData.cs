using LAUCHA.domain.entities.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.Data
{
    internal class AdicionalData : IEntityTypeConfiguration<Adicional>
    {
        public void Configure(EntityTypeBuilder<Adicional> builder)
        {
            builder.HasData(
                    new Adicional
                    {
                        Codigo = "3040",
                        Concepto = "Adicional Titulo Universitario",
                        EsPorcentual = true,
                        Monto = 2
                    },
                    new Adicional
                    {
                        Codigo = "3050",
                        Concepto = "Adicional viaticos",
                        EsPorcentual = false,
                        Monto = 2000
                    },
                    new Adicional
                    {
                        Codigo = "3060",
                        Concepto = "Adicional por trabajo riesgoso",
                        EsPorcentual = false,
                        Monto = 10000
                    },
                    new Adicional
                    {
                        Codigo = "3070",
                        Concepto = "Adicional Extra Plus",
                        EsPorcentual = false,
                        Monto = 90000
                    }
                );
        }
    }
}
