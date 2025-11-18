using LAUCHA.domain.Entities.RetencionesCatalogo;

namespace LAUCHA.domain.Entities.Acuerdos
{
    public class RetencionAcuerdo
    {
        public string CodigoRetencion { get; set; } = string.Empty;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public bool PrimeraQuincena { get; set; }

        public string CodigoAcuerdo { get; set; } = string.Empty;

        public static RetencionAcuerdo Generar(CatalogoRetencion catalogo, Acuerdo acuerdo)
        {
            return new RetencionAcuerdo
            {
                CodigoRetencion = catalogo.Codigo,
                Concepto = catalogo.Concepto,
                EsPorcentual = catalogo.EsPorcentual,
                Unidades = catalogo.Unidades,
                PrimeraQuincena = catalogo.PrimeraQuincena,
                CodigoAcuerdo = acuerdo.Codigo
            };
        }
    }
}
