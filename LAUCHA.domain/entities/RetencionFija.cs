namespace LAUCHA.domain.entities
{
    public class RetencionFija
    {
        public string CodigoRetencionFija { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public bool EsQuincenal { get; set; }
        public ICollection<HistorialRetencionFija> HistorialRetencionesFijas { get; set; } = null!;
        public IList<RetencionFijaPorCuenta> RetencionesFijasPorCuenta { get; set; } = null!;

    }
}
