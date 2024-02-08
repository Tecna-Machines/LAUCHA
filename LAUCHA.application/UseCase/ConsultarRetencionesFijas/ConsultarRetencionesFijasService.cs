using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ConsultarRetencionesFijas
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

        public RetencionFijaDTO ConsultarUnaRetencionFija(string codigoRetencion)
        {
            RetencionFija retencion = _RetencionFijaRepository.GetById(codigoRetencion);

            if(retencion == null) { throw new NullReferenceException(); }

            return _RetencionFijaMapper.GenerarRetencionFijaDTO(retencion);
        }
    }
}
