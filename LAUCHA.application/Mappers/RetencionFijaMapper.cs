using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.Entities.RetencionesCatalogo;

namespace LAUCHA.application.Mappers
{
    internal class RetencionFijaMapper
    {
        public RetencionCatalogo GenerarRetencionFija(RetencionFijaDTO retencionFijaDTO)
        {
            return new RetencionCatalogo
            {
                Codigo = retencionFijaDTO.Codigo,
                Concepto = retencionFijaDTO.Concepto,
                EsPorcentual = retencionFijaDTO.EsPorcentual,
                Unidades = retencionFijaDTO.Unidades,
                PrimeraQuincena = retencionFijaDTO.EsQuincenal
            };
        }

        public RetencionFijaDTO GenerarRetencionFijaDTO(RetencionCatalogo retencionFija)
        {
            return new RetencionFijaDTO
            {
                Codigo = retencionFija.Codigo,
                Concepto = retencionFija.Concepto,
                EsPorcentual = retencionFija.EsPorcentual,
                Unidades = retencionFija.Unidades,
                EsQuincenal = retencionFija.PrimeraQuincena
            };
        }
    }
}
