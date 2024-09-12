using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo4
{
    public class ModuloCalculadorSueldoHsExtra : IModuloLiquidador
    {
        public Task EjecutarRutina(LiquidacionPayload payload)
        {
            //TODO: por completar
            Console.WriteLine("MODULO DE HS EXTRA VIVO");
            return Task.CompletedTask;
        }
    }
}
