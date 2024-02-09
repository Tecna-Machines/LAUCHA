using LAUCHA.application.DTOs.RemuneracionDTOs;
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
            return new Remuneracion
            {
                CodigoRemuneracion = remuneracionDTO.Codigo,
                Descripcion = remuneracionDTO.Descripcion,
                EsBlanco = remuneracionDTO.EsBlanco,
                NumeroCuenta = remuneracionDTO.Cuenta,
                Fecha = DateTime.Now,
                Monto = remuneracionDTO.Monto
            };
        }
    }
}
