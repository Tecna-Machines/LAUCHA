using LAUCHA.domain.Entities.RetencionesCatalogo;

namespace LAUCHA.infrastructure.Data
{
    internal class RetencionesFijasData : IEntityTypeConfiguration<CatalogoRetencion>
    {
        public void Configure(EntityTypeBuilder<CatalogoRetencion> builder)
        {
            builder.HasData(
                    new CatalogoRetencion
                    {
                        Codigo = "0900",
                        Concepto = "Jubilacion",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = 11
                    },
                    new CatalogoRetencion
                    {
                        Codigo = "0905",
                        Concepto = "Ley 19032",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = 3
                    },
                    new CatalogoRetencion
                    {
                        Codigo = "0940",
                        Concepto = "Seguro y Sepelio",
                        EsPorcentual = false,
                        PrimeraQuincena = true,
                        Unidades = 2300
                    },
                    new CatalogoRetencion
                    {
                        Codigo = "0910",
                        Concepto = "Obra Social",
                        EsPorcentual = true,
                        PrimeraQuincena = false,
                        Unidades = 3
                    },
                    new CatalogoRetencion
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
