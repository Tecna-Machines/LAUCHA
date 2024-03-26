using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;

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
                Unidades = retencionFijaDTO.Unidades,
                EsQuincenal = retencionFijaDTO.EsQuincenal
            };
        }

        public RetencionFijaDTO GenerarRetencionFijaDTO(RetencionFija retencionFija)
        {
            return new RetencionFijaDTO
            {
                Codigo = retencionFija.CodigoRetencionFija,
                Concepto = retencionFija.Concepto,
                EsPorcentual = retencionFija.EsPorcentual,
                Unidades = retencionFija.Unidades,
                EsQuincenal = retencionFija.EsQuincenal
            };
        }
    }
}
