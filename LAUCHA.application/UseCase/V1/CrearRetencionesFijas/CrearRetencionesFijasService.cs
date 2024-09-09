using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.CrearRetencionesFijas
{
    public class CrearRetencionesFijasService : ICrearRetencionesFijasService
    {
        private readonly IGenericRepository<RetencionFija> _RetencionFijaRepository;
        private readonly RetencionFijaMapper _RetencionFijaMapper;
        private readonly ILogsApp log;

        public CrearRetencionesFijasService(IGenericRepository<RetencionFija> retencionFijaRepository, ILogsApp log)
        {
            _RetencionFijaRepository = retencionFijaRepository;
            _RetencionFijaMapper = new();
            this.log = log;
        }

        public RetencionFijaDTO CrearNuevaRetencionFija(RetencionFijaDTO nuevaRetencionFija)
        {
            log.LogInformation("se esta creando una retencion: descripcion: {d},monto: {m}",
               nuevaRetencionFija.Concepto, nuevaRetencionFija.Unidades);

            RetencionFija retencionFija = _RetencionFijaMapper.GenerarRetencionFija(nuevaRetencionFija);

            _RetencionFijaRepository.Insert(retencionFija);

            retencionFija = _RetencionFijaRepository.GetById(nuevaRetencionFija.Codigo);

            log.LogInformation("se creo la nueva retencion fija con el codigo: {cod}", retencionFija.CodigoRetencionFija);

            return _RetencionFijaMapper.GenerarRetencionFijaDTO(retencionFija);
        }
    }
}
