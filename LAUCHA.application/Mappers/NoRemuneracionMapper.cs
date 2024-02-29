using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.domain.entities;

namespace LAUCHA.application.Mappers
{
    internal class NoRemuneracionMapper
    {
        private readonly GeneradorDeNumeroAleatorio _NumeroAleatorio = new();
        public NoRemuneracionDTO GenerarDtoNoRemuneracion(NoRemuneracion noRemuneracion)
        {
            return new NoRemuneracionDTO
            {
                Codigo = noRemuneracion.CodigoNoRemuneracion,
                Cuenta = noRemuneracion.NumeroCuenta,
                Descripcion = noRemuneracion.Descripcion,
                Fecha = noRemuneracion.Fecha.ToString("dd/MM/yyyy HH:mm"),
                Monto = noRemuneracion.Monto
            };
        }

        public NoRemuneracion GenerarNoRemuneracion(CrearNoRemuneracionDTO noRemuneracionDTO)
        {
            DateTime fechaActual = DateTime.Now;
            int numeroRandom = _NumeroAleatorio.GenerarAleatorioEntreValores(0, fechaActual.Second + fechaActual.Millisecond);

            string codigo = $"NO|REM:{noRemuneracionDTO.Cuenta}{fechaActual.Year}" +
                            $"{fechaActual.Hour}{fechaActual.Second}{numeroRandom}";

            return new NoRemuneracion
            {
                CodigoNoRemuneracion = codigo,
                Fecha = DateTime.Now,
                NumeroCuenta = noRemuneracionDTO.Cuenta,
                Descripcion = noRemuneracionDTO.Descripcion,
                Monto = noRemuneracionDTO.Monto
            };
        }
    }
}
