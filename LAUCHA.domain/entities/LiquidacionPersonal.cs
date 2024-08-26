namespace LAUCHA.domain.entities
{
    public class LiquidacionPersonal
    {
        public string CodigoLiquidacion { get; set; } = null!;
        public decimal TotalRemuneraciones { get; set; }
        public decimal TotalNoRemunerativo { get; set; }
        public decimal TotalRetenciones { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal TotalSueldo { get; set; }
        public string Concepto { get; set; } = null!;
        public DateTime FechaLiquidacion { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public DateTime FinPeriodo { get; set; }
        public string CodigoContrato { get; set; } = null!;
        public Contrato Contrato { get; set; } = null!;
        public ICollection<PagoLiquidacion> PagosLiquidacion { get; set; } = null!;
        public IList<RemuneracionPorLiquidacionPersonal> RemuneracionPorLiquidacionPersonales { get; set; } = null!;
        public IList<RetencionPorLiquidacionPersonal> RetencionPorLiquidacionPersonales { get; set; } = null!;
        public IList<DescuentoPorLiquidacionPersonal> DescuentoPorLiquidacionPersonales { get; set; } = null!;
        public IList<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionesPorLiquidaciones { get; set; } = null!;

        public string? CodigoLiquidacionGeneral { get; set; }
        public LiquidacionGeneral? LiquidacionGeneral;


    }
}
