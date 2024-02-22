﻿namespace LAUCHA.application.DTOs.LiquidacionDTO
{
    internal class LiquidacionDTO
    {
        public string Codigo { set; get; } = null!;
        public string Dni { get; set; } = null!;
        public string Empleado { set; get; } = null!;
        public DateTime Fecha { get; set; }
        public ItemsDTO Items { set; get; } = null!;
        public decimal TotalBrutoBanco { set; get; }
        public decimal TotalBrutoEfectivo { set; get; }
        public decimal TotalPagarBanco { set; get; }
        public decimal TotalPagarEfectivo { get; set; }
        public List<PagoDTO> Pagos { get; set; } = null!;
    }
}