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

namespace LAUCHA.application.UseCase.CrearRetencionesFijas
{
    public class CrearRetencionesFijasService : ICrearRetencionesFijasService
    {
        private readonly IGenericRepository<RetencionFija> _RetencionFijaRepository;
        private readonly RetencionFijaMapper _RetencionFijaMapper;

        public CrearRetencionesFijasService(IGenericRepository<RetencionFija> retencionFijaRepository)
        {
            _RetencionFijaRepository = retencionFijaRepository;
            _RetencionFijaMapper = new();
        }

        public RetencionFijaDTO CrearNuevaRetencionFija(RetencionFijaDTO nuevaRetencionFija)
        {
            RetencionFija retencionFija = _RetencionFijaMapper.GenerarRetencionFija(nuevaRetencionFija);

            _RetencionFijaRepository.Insert(retencionFija);

            retencionFija = _RetencionFijaRepository.GetById(nuevaRetencionFija.Codigo);

            return _RetencionFijaMapper.GenerarRetencionFijaDTO(retencionFija);
        }
    }
}
