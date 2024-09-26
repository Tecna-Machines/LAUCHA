using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo6
{
    public class ModuloCalculadorDeRetenciones : IModuloLiquidador
    {
        public Task EjecutarRutina(LiquidacionPayload payload)
        {

            payload.retencionesLiquidacion.AddRange(this.CalcularRetencionesDeLiquidacion(payload));
            return Task.CompletedTask;
        }

        private List<Retencion> CalcularRetencionesDeLiquidacion(LiquidacionPayload payload)
        {
            var calculadora = payload.GetCalculadoraSueldo() ?? throw new ArgumentException();

            decimal montoRemunerativoTotal = payload.GetMontoRemunerativo();

            return calculadora.CalcularRetencionesSueldo(desde: payload.periodoliquidar.Inicio,
                                                         hasta: payload.periodoliquidar.Fin,
                                                         montoBrutoBlanco: montoRemunerativoTotal,
                                                         cuentaConRetenciones: payload.Cuenta);
        }
    }
}
