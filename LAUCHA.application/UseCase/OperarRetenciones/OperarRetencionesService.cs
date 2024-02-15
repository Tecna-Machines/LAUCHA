using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.OperarRetenciones
{
    public class OperarRetencionesService : IOperarRetencionService
    {
        private readonly IGenericRepository<Retencion> _RetencionRepository;
        private readonly RetencionMapper _RetencionMapper;

        public OperarRetencionesService(IGenericRepository<Retencion> retencionRepository)
        {
            _RetencionRepository = retencionRepository;
            _RetencionMapper = new();
        }

        public RetencionDTO CrearRetencion(CrearRetencionDTO nuevaRetencionDTO)
        {
            Retencion nuevaRetencion = _RetencionMapper.GenerarRetencion(nuevaRetencionDTO);

            nuevaRetencion =  _RetencionRepository.Insert(nuevaRetencion);
            _RetencionRepository.Save();

            return _RetencionMapper.GenerarRetencionDTO(nuevaRetencion);
        }
    }
}
