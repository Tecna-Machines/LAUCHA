namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal static class GeneradorSueldoEnBlanco
    {


        public static ItemLiquidacion Generar(Liquidacion liq, Acuerdo acu)
        {
            var result = (acu.TipoSueldo) switch
            {
                TipoSueldo.MENSUAL_FIJO => GenerarMensual(liq, acu),
                TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA => GenerarMensual(liq, acu),
                TipoSueldo.QUINCENAL_FIJO => GeneralQuincenal(liq, acu),
                TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA => GeneralQuincenal(liq, acu),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return result;
        }

        public static ItemLiquidacion GenerarMensual(Liquidacion liq, Acuerdo acu)
        {
            var sueldoEnBlanco = ItemLiquidacion
                                .CrearRemunerativo("Sueldo Mensual", acu.ValorSueldoOJornal);

            return sueldoEnBlanco;
        }

        public static ItemLiquidacion GeneralQuincenal(Liquidacion liq, Acuerdo acu)
        {
            int hsBlanco;
            decimal montoSueldo;
            Random random = new Random();


            if (acu.ValorSueldoOJornal == acu.Sueldo)
            {
                //como son iguales sera una jornada completa (genera horas entre 95 y 100)
                hsBlanco = random.Next(95, 101);
            }
            else
            {
                //se considera media jornada (genera horas entre 40 y 50)
                hsBlanco = random.Next(40, 51);
            }

            hsBlanco = 44; //hardcodeado para una prueba

            montoSueldo = hsBlanco * acu.ValorSueldoOJornal;


            return ItemLiquidacion.CrearRemunerativo($"Horas trabajadas ({hsBlanco})", montoSueldo);
        }


    }
}
