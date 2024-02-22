using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Helpers
{
    internal class CalculadorDePorcentaje
    {
        public decimal CalcularPorcentajeDeMonto(decimal porcentaje,decimal montoTotal)
        {
            decimal unPorCiento = montoTotal / 100;
            return unPorCiento * porcentaje;
        }

        public decimal AumentarSegunPorcentaje(decimal porcentajeIncrementar,decimal montoOriginal)
        {
            // Calcular el incremento
            decimal incremento = montoOriginal * (porcentajeIncrementar / 100);

            // Sumar el incremento al monto original
            decimal nuevoMonto = montoOriginal + incremento;

            return nuevoMonto;
        }

        public decimal CalcularPorcentajeSiEstaHabilitado(bool esPorcentual,decimal unidades,decimal montoTotal)
        {
            if (esPorcentual) 
            {
                decimal unPorCiento = montoTotal / 100;
                return unPorCiento * unidades;
            }

            return unidades;
        }
    }
}
