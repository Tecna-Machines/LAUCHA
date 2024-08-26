﻿namespace LAUCHA.domain.entities
{
    public class DescuentoPorLiquidacionPersonal
    {
        public string CodigoDescuento { get; set; } = null!;
        public Descuento Descuento { get; set; } = null!;
        public string CodigoLiquidacionPersonal { get; set; } = null!;
        public LiquidacionPersonal LiquidacionPersonal { get; set; } = null!;
    }
}
