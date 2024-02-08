using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Mappers
{
    internal class RetencionFijaMapper
    {
        public RetencionFija GenerarRetencionFija(RetencionFijaDTO retencionFijaDTO)
        {
            return new RetencionFija
            {
                CodigoRetencionFija = retencionFijaDTO.Codigo,
                Concepto = retencionFijaDTO.Concepto,
                EsPorcentual = retencionFijaDTO.EsPorcentual,
                Unidades = retencionFijaDTO.Unidades
            };
        }

        public RetencionFijaDTO GenerarRetencionFijaDTO(RetencionFija retencionFija)
        {
            return new RetencionFijaDTO
            {
                Codigo = retencionFija.CodigoRetencionFija,
                Concepto = retencionFija.Concepto,
                EsPorcentual = retencionFija.EsPorcentual,
                Unidades = retencionFija.Unidades
            };
        }
    }
}
