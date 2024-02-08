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
    internal class RetencionesFijasData : IEntityTypeConfiguration<RetencionFija>
    {
        public void Configure(EntityTypeBuilder<RetencionFija> builder)
        {
            builder.HasData(
                    new RetencionFija
                    {
                        CodigoRetencionFija = "0900",
                        Concepto = "Jubilacion",
                        EsPorcentual = true,
                        EsQuincenal = false,
                        Unidades = 11
                    },
                    new RetencionFija
                    {
                        CodigoRetencionFija = "0905",
                        Concepto = "Ley 19032",
                        EsPorcentual = true,
                        EsQuincenal = false,
                        Unidades = 3
                    },
                    new RetencionFija
                    {
                        CodigoRetencionFija = "0940",
                        Concepto = "Seguro y Sepelio",
                        EsPorcentual = false,
                        EsQuincenal = true,
                        Unidades = 2300
                    },
                    new RetencionFija
                    {
                        CodigoRetencionFija = "0910",
                        Concepto = "Obra Social",
                        EsPorcentual = true,
                        EsQuincenal = false,
                        Unidades = 3
                    },
                    new RetencionFija
                    {
                        CodigoRetencionFija = "0920",
                        Concepto = "Aporte Sindical Obligatorio",
                        EsPorcentual = true,
                        EsQuincenal = false,
                        Unidades = Convert.ToDecimal(2.5)
                    }
                );
        }
    }
}
