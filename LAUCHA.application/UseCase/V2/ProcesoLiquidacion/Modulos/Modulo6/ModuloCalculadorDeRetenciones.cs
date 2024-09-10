using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo6
{
    public class ModuloCalculadorDeRetenciones : IModuloLiquidador
    {
        public void EjecutarRutina(LiquidacionPayload payload)
        {

            payload.retencionesLiquidacion.AddRange(this.CalcularRetencionesDeLiquidacion(payload));
        }

        private List<Retencion> CalcularRetencionesDeLiquidacion(LiquidacionPayload payload)
        {
            var calculadora = payload.GetCalculadoraSueldo() ?? throw new ArgumentException();

            decimal montoRemunerativoTotal = payload.GetMontoRemunerativo();

            return calculadora.CalcularRetencionesSueldo(montoBrutoBlanco: montoRemunerativoTotal,
                                                         cuentaConRetenciones: payload.Cuenta);
        }
    }
}
