using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
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

        public void EjecutarRutina(LiquidacionPayload payload)
        {
            decimal montoRemunerativoBase = payload.GetMontoRemunerativo();

            EmpleadoMapper mapperEmpleado = new();
            var empleado = mapperEmpleado.GenerarEmpleado(payload.Empleado);

            Remuneracion antiguedad = _calculadoraAntiguedad.CalcularAntiguedad(empleado, montoRemunerativoBase);

            payload.remuneracionesLiquidacion.Add(antiguedad);
        }

    }
}
