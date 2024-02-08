using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    internal class CuentaMapper
    {
        private readonly RetencionFijaMapper _RetencionFijaMapper = new();
        public CuentaDTO GenerarCuentaDTO(Cuenta cuenta,Empleado empleado,List<RetencionFija> retencionesFijas )
        {
            List<RetencionFijaDTO> retencionesDTOs = new List<RetencionFijaDTO> ();

            foreach (var retencionFija in retencionesFijas)
            {
                var retencionMapeada = _RetencionFijaMapper.GenerarRetencionFijaDTO(retencionFija);
                retencionesDTOs.Add(retencionMapeada);
            }

            return new CuentaDTO
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                Empleado = $"{empleado.Nombre} {empleado.Apellido}",
                Retenciones = retencionesDTOs
            };
        }
    }
}
