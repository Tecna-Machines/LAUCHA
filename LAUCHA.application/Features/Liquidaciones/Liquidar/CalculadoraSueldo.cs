using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class CalculadoraSueldo : ICalculadoraDeSueldos
    {


        public ICollection<ItemLiquidacion> CalcularItemsSueldo(Liquidacion liq, Acuerdo acu)
        {
            var result = (acu.TipoSueldo) switch
            {
                TipoSueldo.Mensual => CalcularMensual(liq, acu),
                TipoSueldo.MensualFijoMasExtra => CalcularMensual(liq, acu),
                TipoSueldo.QuincenalFijo => CalcularQuincenal(liq, acu),
                TipoSueldo.QuincenalHora => CalcularQuincenal(liq, acu),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return result;
        }

        public ICollection<ItemLiquidacion> CalcularMensual(Liquidacion liq, Acuerdo acu)
        {
            var sueldoEnBlanco = ItemLiquidacion
                                .CrearRemunerativo("sueldo mensual", acu.ValorBlanco);

            var sueldoEnNegro = ItemLiquidacion
                                .CrearRemunerativoEnNegro("sueldo mensual", acu.Sueldo);

            return new List<ItemLiquidacion> { sueldoEnBlanco, sueldoEnNegro };
        }

        public ICollection<ItemLiquidacion> CalcularQuincenal(Liquidacion liq, Acuerdo acu)
        {
            var sueldoEnBlanco = ItemLiquidacion.CrearRemunerativo("sueldo mensual", acu.ValorBlanco / 2);
            var sueldoEnNegro = ItemLiquidacion.CrearRemunerativoEnNegro("sueldo mensual", acu.Sueldo / 2);

            return new List<ItemLiquidacion> { sueldoEnBlanco, sueldoEnNegro };
        }
    }
}
