using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V1.HacerUnaLiquidacion
{
    public class CalculadoraAntiguedad : ICalculadoraAntiguedad
    {
        private RemuneracionMapper _RemuneracionMapper;

        public CalculadoraAntiguedad()
        {
            _RemuneracionMapper = new();
        }

        public Remuneracion CalcularAntiguedad(Empleado empleado, decimal montoBrutoBlanco)
        {
            DateTime fechaIngreso = empleado.FechaIngreso;
            DateTime fechaActual = DateTime.Now;

            int aniosAntiguedad = fechaActual.Year - fechaIngreso.Year;

            if (fechaActual.Month < fechaIngreso.Month)
            {
                aniosAntiguedad--;
            }
            else if (fechaActual.Month == fechaIngreso.Month)
            {
                if (fechaActual.Day < fechaIngreso.Day)
                {
                    aniosAntiguedad--;
                }
            }

            if (aniosAntiguedad < 0)
            {
                aniosAntiguedad = 0;
            }

            decimal montoAntiguedad = montoBrutoBlanco / 100 * aniosAntiguedad;

            var remuneracionDTO = new RemuneracionDTO
            {
                Descripcion = $"Antiguedad ({aniosAntiguedad})",
                Cuenta = empleado.Cuenta.NumeroCuenta,
                EsBlanco = true,
                Monto = montoAntiguedad
            };

            return _RemuneracionMapper.GenerarRemuneracion(remuneracionDTO);
        }
    }
}
