using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    internal class RemuneracionMapper
    {
        private readonly GeneradorDeNumeroAleatorio _NumeroAleatorio = new();
        public RemuneracionDTO GenerarRemuneracionDTO(Remuneracion remuneracion)
        {
            return new RemuneracionDTO
            {
                Codigo = remuneracion.CodigoRemuneracion,
                Descripcion = remuneracion.Descripcion,
                Cuenta = remuneracion.NumeroCuenta,
                EsBlanco = remuneracion.EsBlanco,
                Fecha = remuneracion.Fecha.ToString("dd-MM-yyyy HH:mm"),
                Monto = remuneracion.Monto
            };
        }

        public Remuneracion GenerarRemuneracion(RemuneracionDTO remuneracionDTO)
        {
            DateTime fechaActual = DateTime.Now;
            int numeroRandom = _NumeroAleatorio.GenerarAleatorioEntreValores(0,fechaActual.Second+ fechaActual.Millisecond);

            return new Remuneracion
            {
                CodigoRemuneracion = $"{remuneracionDTO.Cuenta}{fechaActual.Year}{fechaActual.Hour}{fechaActual.Second}{numeroRandom}",
                Descripcion = remuneracionDTO.Descripcion,
                EsBlanco = remuneracionDTO.EsBlanco,
                NumeroCuenta = remuneracionDTO.Cuenta,
                Fecha = DateTime.Now,
                Monto = remuneracionDTO.Monto
            };
        }
    }
}
