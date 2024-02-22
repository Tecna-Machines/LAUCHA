using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class LiquidacionPersonal
    {
        public string CodigoLiquidacion { get; set; } = null!;
        public decimal TotalRemuneraciones { get; set; }
        public decimal TotalRetenciones { get; set; }
        public decimal TotalDescuentos { get; set; }
        public string Concepto { get; set; } = null!;
        public DateTime FechaLiquidacion { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public DateTime FinPeriodo { get; set; }
        public ICollection<PagoLiquidacion> PagosLiquidacion { get; set; } = null!;
        public IList<RemuneracionPorLiquidacionPersonal> RemuneracionPorLiquidacionPersonales { get; set; } = null!;
        public IList<RetencionPorLiquidacionPersonal> RetencionPorLiquidacionPersonales { get; set; } = null!;
        public IList<DescuentoPorLiquidacionPersonal> DescuentoPorLiquidacionPersonales { get; set; } = null!;
        public IList<CuotaPorLiquidacionPersonal> CuotasPorLiquidaciones { get; set; } = null!;
        public IList<SubCuotaPorLiquidacion> SubCuotasPorLiquidaciones { get; set; } = null!;

        public string? CodigoLiquidacionGeneral { get; set; }
        public LiquidacionGeneral? LiquidacionGeneral;


    }
}
