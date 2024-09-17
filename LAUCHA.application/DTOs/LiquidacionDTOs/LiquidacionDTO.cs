using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.DTOs.LiquidacionDTOs
{
    public class LiquidacionDTO
    {
        public string Codigo { set; get; } = null!;
        public string Dni { get; set; } = null!;
        public string Empleado { set; get; } = null!;
        public string Concepto { set; get; } = null!;
        public DateTime Fecha { get; set; }
        public PeriodoDTO Periodo { get; set; } = null!;
        public ContratoDTO Contrato { get; set; } = null!;
        public ItemsDTO Items { set; get; } = null!;
        public decimal TotalBrutoBanco { set; get; }
        public decimal TotalBrutoEfectivo { set; get; }
        public decimal TotalPagarBanco { set; get; }
        public decimal TotalPagarEfectivo { get; set; }
        public List<PagoDTO> Pagos { get; set; } = null!;
        public List<MarcaVista> Marcas { get; set; } = null!;
    }
}
