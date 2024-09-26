using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo5
{
    public class ModuloCalculadorAntiguedad : IModuloLiquidador
    {
        private readonly ICalculadoraAntiguedad _calculadoraAntiguedad;

        public ModuloCalculadorAntiguedad(ICalculadoraAntiguedad calculadoraAntiguedad)
        {
            _calculadoraAntiguedad = calculadoraAntiguedad;
        }

        public Task EjecutarRutina(LiquidacionPayload payload)
        {
            bool esPrimeraQuincena = payload.periodoliquidar.Inicio.Day < 15;
            
            if(esPrimeraQuincena)
            {
                return Task.CompletedTask;
            }

            decimal montoRemunerativoBase = payload.GetMontoRemunerativo();


            Remuneracion antiguedad = _calculadoraAntiguedad.CalcularAntiguedad(payload.Empleado, montoRemunerativoBase);

            payload.remuneracionesLiquidacion.Add(antiguedad);
            return Task.CompletedTask;
        }

    }
}
