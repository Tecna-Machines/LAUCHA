namespace LAUCHA.domain.Entities.Liquidaciones
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

        /// <summary>
        /// si el item es generado por la aplicacion queda marcada
        /// si lo hace un usuario esta propiedad queda en false
        /// </summary>
        public bool generadoPorUsuario { get; set; } = true;
        public EstadoItemLiquidacion Estado { get; set; }
        public TipoItemLiquidacion   Tipo { get; set; }

        public static ItemLiquidacion CrearRemunerativo(string concepto, decimal monto)
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

        public static ItemLiquidacion CrearRetencion(string concepto, decimal monto)
        {
            return new ItemLiquidacion
            {
                Concepto = concepto,
                Monto = monto,
                EsEnBlanco = true,
                EsIncremento = false,
                Fecha = DateTime.Now,
                Estado = EstadoItemLiquidacion.ACEPTADO,
                Tipo = TipoItemLiquidacion.Retencion
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

        public static ItemLiquidacion CrearRemunerativoEnNegro(string concepto, decimal monto)
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
        public void Anular()
        {
            Estado = EstadoItemLiquidacion.ANULADO;
        }

        public void MarcarComoGeneradoPorElSistema()
        {
            generadoPorUsuario = false;
        }

    }
}
