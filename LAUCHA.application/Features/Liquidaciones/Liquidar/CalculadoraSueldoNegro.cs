using LAUCHA.domain.Entities.Acuerdos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal static class CalculadoraSueldoNegro
    {
        public static ItemLiquidacion Calcular(Liquidacion liq, Acuerdo acu)
        {
            var result = (acu.TipoSueldo) switch
            {
                TipoSueldo.Mensual => CalcularMensualNegro(liq, acu),
                TipoSueldo.MensualFijoMasExtra => CalcularMensualNegro(liq, acu),
                TipoSueldo.QuincenalFijo => CalcularQuincenalNegro(liq, acu),
                TipoSueldo.QuincenalHora => CalcularQuincenalNegro(liq, acu),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return result;
        }

        private static ItemLiquidacion CalcularQuincenalNegro(Liquidacion liq, Acuerdo acu)
        {
            return ItemLiquidacion.CrearRemunerativoEnNegro("sueldo mensual", acu.Sueldo/2);
        }

        private static ItemLiquidacion CalcularMensualNegro(Liquidacion liq, Acuerdo acu)
        {
            return ItemLiquidacion.CrearRemunerativoEnNegro("sueldo mensual", acu.Sueldo);
        }
    }
}
