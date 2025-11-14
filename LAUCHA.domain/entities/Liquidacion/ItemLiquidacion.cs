namespace LAUCHA.domain.Entities.Liquidacion
{
    public class ItemLiquidacion
    {
        public int NroItem { get; set; }
        public string CodigoLiquidacion { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsEnBlanco { get; set; }
        public bool EsIncremento { get; set; }
        public EstadoItemLiquidacion Estado { get; set; }
        public TipoItemLiquidacion Tipo { get; set; }

        public static ItemLiquidacion CrearItemRemunerativo(string concepto, decimal monto)
        {
            return new ItemLiquidacion
            {
                Concepto = concepto,
                Monto = monto,
                EsEnBlanco = true,
                EsIncremento = true,
                Tipo = TipoItemLiquidacion.Remunerativo,
                Fecha = DateTime.Now,
                Estado = EstadoItemLiquidacion.ACEPTADO
            };
        }

        public static ItemLiquidacion CrearDescuento(string concepto, decimal monto)
        {
            return new ItemLiquidacion
            {
                Concepto = concepto,
                Monto = monto,
                EsEnBlanco = true,
                EsIncremento = false,
                Fecha = DateTime.Now,
                Estado = EstadoItemLiquidacion.ACEPTADO,
                Tipo = TipoItemLiquidacion.Descuento
            };
        }

        public static ItemLiquidacion CrearNoRemunerativo(string concepto, decimal monto)
        {
            return new ItemLiquidacion
            {
                Concepto = concepto,
                Monto = monto,
                EsEnBlanco = true,
                EsIncremento = false,
                Fecha = DateTime.Now,
                Estado = EstadoItemLiquidacion.ACEPTADO,
                Tipo = TipoItemLiquidacion.NoRemunerativo
            };
        }

        public static ItemLiquidacion CrearRemuneracionEnNegro(string concepto, decimal monto)
        {
            return new ItemLiquidacion
            {
                Concepto = concepto,
                Monto = monto,
                EsEnBlanco = false,
                EsIncremento = true,
                Fecha = DateTime.Now,
                Estado = EstadoItemLiquidacion.ACEPTADO,
                Tipo = TipoItemLiquidacion.Remunerativo
            };
        }

        public static ItemLiquidacion CrearDescuentoEnNegro(string concepto, decimal monto)
        {
            return new ItemLiquidacion
            {
                Concepto = concepto,
                Monto = monto,
                EsEnBlanco = false,
                EsIncremento = false,
                Fecha = DateTime.Now,
                Estado = EstadoItemLiquidacion.ACEPTADO,
                Tipo = TipoItemLiquidacion.Descuento
            };
        }

        public void AsociarLiquidacion(Liquidacion liq)
        {
            CodigoLiquidacion = liq.Codigo;
        }
        public void Anular()
        {
            Estado = EstadoItemLiquidacion.ANULADO;
        }
    }
}
