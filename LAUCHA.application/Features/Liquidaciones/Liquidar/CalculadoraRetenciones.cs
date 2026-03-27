namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class CalculadoraRetenciones : ICalculadoraRetenciones
    {
        public ICollection<ItemLiquidacion> CalcularItemsRetenciones(Liquidacion liq, Acuerdo acu)
        {
            if (acu.TipoSueldo == TipoSueldo.QuincenalFijo || acu.TipoSueldo == TipoSueldo.QuincenalFijoMasExtras)
            {
                return CalcularRetencionesQuincenal(liq, acu);
            }

            return CalcularRetencionesMensual(liq, acu);
        }

        private ICollection<ItemLiquidacion> CalcularRetencionesQuincenal(Liquidacion liq, Acuerdo acu)
        {
            List<ItemLiquidacion> ItemsRetenciones = new();

            decimal montoRemunerativo = liq.CalcularNetoBlanco();
            IEnumerable<RetencionAcuerdo> retencionesAcuerdo;

            if (liq.EsPrimeraQuincena())
            {
                retencionesAcuerdo = acu.GetRetencionesPrimeraQuincena();
            }
            else
            {
                retencionesAcuerdo = acu.GetRetencionesSegundaQuincena();
            }

            foreach (var retencion in retencionesAcuerdo)
            {
                var item = GenerarItemRetencion(retencion, montoRemunerativo);
                ItemsRetenciones.Add(item);
            }

            return ItemsRetenciones;
        }

        private ICollection<ItemLiquidacion> CalcularRetencionesMensual(Liquidacion liq, Acuerdo acu)
        {
            List<ItemLiquidacion> ItemsRetenciones = new();

            decimal montoRemunerativo = liq.CalcularNetoBlanco();
            IEnumerable<RetencionAcuerdo> retencionesAcuerdo = acu.GetRetenciones();

            foreach (var retencion in retencionesAcuerdo)
            {
                var item = GenerarItemRetencion(retencion, montoRemunerativo);
                ItemsRetenciones.Add(item);
            }

            return ItemsRetenciones;
        }

        private ItemLiquidacion GenerarItemRetencion(RetencionAcuerdo ret, decimal totalRemunerativo)
        {
            decimal monto;

            if (!ret.EsPorcentual)
            {
                monto = ret.Unidades;
            }
            else
            {
                monto = CalculadorDePorcentaje.GetMontoSegunPorcentaje(ret.Unidades, totalRemunerativo);
            }

            return ItemLiquidacion.CrearRetencion(ret.Concepto, monto);
        }
    }
}
