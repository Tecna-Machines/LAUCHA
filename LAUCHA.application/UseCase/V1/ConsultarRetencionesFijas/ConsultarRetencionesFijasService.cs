using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V1.ConsultarRetencionesFijas
{
    public class ConsultarRetencionesFijasService : IConsultarRetencionesFijasService
    {
        private readonly IGenericRepository<RetencionFija> _RetencionFijaRepository;
        private readonly RetencionFijaMapper _RetencionFijaMapper;

        public ConsultarRetencionesFijasService(IGenericRepository<RetencionFija> retencionFijaRepository)
        {
            _RetencionFijaRepository = retencionFijaRepository;
            _RetencionFijaMapper = new();
        }

        public List<RetencionFijaDTO> ConsultarRetencionesFijas()
        {
            List<RetencionFija> retencionesFijas = _RetencionFijaRepository.GetAll().ToList();
            List<RetencionFijaDTO> retencionesFijasDTOs = new();

            foreach (var retencionFija in retencionesFijas)
            {
                var dtoRetencionFija = _RetencionFijaMapper.GenerarRetencionFijaDTO(retencionFija);
                retencionesFijasDTOs.Add(dtoRetencionFija);
            }

            return retencionesFijasDTOs;
        }

        public RetencionFijaConHistorialDTO ConsultarUnaRetencionFija(string codigoRetencion)
        {
            RetencionFija retencion = _RetencionFijaRepository.GetById(codigoRetencion);

            List<HistorialRetencionDTO> historialDTO = new();

            var historial = retencion.HistorialRetencionesFijas.ToList();

            foreach (var registro in historial)
            {
                var dtoHistorial = new HistorialRetencionDTO
                {
                    Unidades = registro.Unidades,
                    EsPorcentual = registro.EsPorcentual,
                    FechaFinVigencia = registro.FechaFinVigencia
                };

                historialDTO.Add(dtoHistorial);
            }

            if (retencion == null) { throw new NullReferenceException(); }

            return new RetencionFijaConHistorialDTO
            {
                Codigo = retencion.CodigoRetencionFija,
                Concepto = retencion.Concepto,
                EsPorcentual = retencion.EsPorcentual,
                EsQuincenal = retencion.EsQuincenal,
                Unidades = retencion.Unidades,
                Historial = historialDTO
            };
        }
    }
}
