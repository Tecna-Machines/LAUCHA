namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal static class CalculadoraSueldoBlanco
    {


        public static ItemLiquidacion Calcular(Liquidacion liq, Acuerdo acu)
        {
            var result = (acu.TipoSueldo) switch
            {
                TipoSueldo.MENSUAL_FIJO => CalcularMensualBlanco(liq, acu),
                TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA => CalcularMensualBlanco(liq, acu),
                TipoSueldo.QUINCENAL_FIJO => CalcularQuincenalBlanco(liq, acu),
                TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA => CalcularQuincenalBlanco(liq, acu),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return result;
        }

        public static ItemLiquidacion CalcularMensualBlanco(Liquidacion liq, Acuerdo acu)
        {
            var sueldoEnBlanco = ItemLiquidacion
                                .CrearRemunerativo("sueldo mensual", acu.ValorBlanco);

            return sueldoEnBlanco;
        }

        public static ItemLiquidacion CalcularQuincenalBlanco(Liquidacion liq, Acuerdo acu)
        {
            return ItemLiquidacion.CrearRemunerativo("sueldo quincena", acu.ValorBlanco / 2);
        }


    }
}
