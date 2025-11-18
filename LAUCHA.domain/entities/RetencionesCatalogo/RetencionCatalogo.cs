namespace LAUCHA.domain.Entities.RetencionesCatalogo
{
    public class RetencionCatalogo
    {
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public bool PrimeraQuincena { get; set; }

    }


}
