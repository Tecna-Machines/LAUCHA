using LAUCHA.domain.Entities.RetencionesCatalogo;

namespace LAUCHA.infrastructure.Data
{
    internal class RetencionesFijasData : IEntityTypeConfiguration<RetencionCatalogo>
    {
        public void Configure(EntityTypeBuilder<RetencionCatalogo> builder)
        {
            builder.HasData(
                    new RetencionCatalogo
                    {
                        Codigo = "0900",
                        Concepto = "Jubilacion",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = 11
                    },
                    new RetencionCatalogo
                    {
                        Codigo = "0905",
                        Concepto = "Ley 19032",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = 3
                    },
                    new RetencionCatalogo
                    {
                        Codigo = "0940",
                        Concepto = "Seguro y Sepelio",
                        EsPorcentual = false,
                        PrimeraQuincena = true,
                        Unidades = 2300
                    },
                    new RetencionCatalogo
                    {
                        Codigo = "0910",
                        Concepto = "Obra Social",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = 3
                    },
                    new RetencionCatalogo
                    {
                        Codigo = "0920",
                        Concepto = "Aporte Sindical Obligatorio",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = Convert.ToDecimal(2.5)
                    }
                );
        }
    }
}
