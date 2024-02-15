using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    internal class RetencionMapper
    {
        public Retencion GenerarRetencion(CrearRetencionDTO retencionDTO)
        {
            DateTime fechaActual = DateTime.Now;

            return new Retencion
            {
                CodigoRetencion = $"R:/{retencionDTO.NumeroCuenta}/{fechaActual.Year}/{fechaActual.Hour}/{fechaActual.Second}",
                Descripcion = retencionDTO.Descripcion,
                Fecha = fechaActual,
                Monto = retencionDTO.Monto,
                NumeroCuenta = retencionDTO.NumeroCuenta
            };
        }

        public RetencionDTO GenerarRetencionDTO(Retencion retencion)
        {
            return new RetencionDTO
            {
                Codigo = retencion.CodigoRetencion,
                Descripcion = retencion.Descripcion,
                Fecha = retencion.Fecha,
                Monto = retencion.Monto,
                NumeroCuenta = retencion.NumeroCuenta
            };
        }
    }
}
