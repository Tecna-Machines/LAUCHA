namespace LAUCHA.domain.entities.Contrato
{
    public class Adicional
    {
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Monto { get; set; }
        public bool EsPorcentual { get; set; }
        public bool EsEnBlanco { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CodigoAcuerdo { get; set; } = null!;

    }
}
