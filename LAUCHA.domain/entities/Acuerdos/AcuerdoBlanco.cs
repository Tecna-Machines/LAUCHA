namespace LAUCHA.domain.Entities.Acuerdos
{
    public class AcuerdoBlanco
    {
        public string CodigoAcuerdoBlanco { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public string CodigoContrato { get; set; } = null!;
        public Acuerdo Contrato { get; set; } = null!;
    }
}
