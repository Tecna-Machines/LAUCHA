namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal static class CalculadoraSueldoNegro
    {
        public static ItemLiquidacion Calcular(Liquidacion liq, Acuerdo acu)
        {
            var result = (acu.TipoSueldo) switch
            {
                TipoSueldo.MENSUAL_FIJO => CalcularMensualNegro(liq, acu),
                TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA => CalcularMensualNegro(liq, acu),
                TipoSueldo.QUINCENAL_FIJO => CalcularQuincenalNegro(liq, acu),
                TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA => CalcularQuincenalNegro(liq, acu),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return result;
        }

        private static ItemLiquidacion CalcularQuincenalNegro(Liquidacion liq, Acuerdo acu)
        {
            return ItemLiquidacion.CrearRemunerativoEnNegro("sueldo quincenal", acu.Sueldo / 2);
        }

        private static ItemLiquidacion CalcularMensualNegro(Liquidacion liq, Acuerdo acu)
        {
            return ItemLiquidacion.CrearRemunerativoEnNegro("sueldo mensual", acu.Sueldo);
        }
    }
}
