using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ConsultarRemuneraciones
{
    public class ConsultarRemuneracionesService : IConsultarRemuneracionService
    {
        private readonly IGenericRepository<Remuneracion> _RemuneracionRepository;
        private readonly IRemuneracionRepository _RemuneracionRepositoryEspecifico;
        private readonly RemuneracionMapper _RemuneracionMapper;

        public ConsultarRemuneracionesService(IGenericRepository<Remuneracion> remuneracionRepository,
                                              IRemuneracionRepository remuneracionRepositoryEspecifico)
        {
            _RemuneracionRepository = remuneracionRepository;
            _RemuneracionRepositoryEspecifico = remuneracionRepositoryEspecifico;
            _RemuneracionMapper = new();
        }

        public RemuneracionDTO ConsularRemuneracion(string codigoRemuneracion)
        {
            Remuneracion remuneracion = _RemuneracionRepository.GetById(codigoRemuneracion);

            if (remuneracion == null) { throw new NullReferenceException(); }

            return _RemuneracionMapper.GenerarRemuneracionDTO(remuneracion);
        }

        public async Task<List<RemuneracionDTO>> ConsularRemuneracionesFiltradas(string? numeroCuenta,
                                                                     string? descripcion,
                                                                     DateTime? desde,
                                                                     DateTime? hasta,
                                                                     string? orden,
                                                                     int index,
                                                                     int cantidad)
        {
           List<Remuneracion> remuneraciones = await _RemuneracionRepositoryEspecifico.
                                                ObtenerRemuneracionesFiltradas(numeroCuenta,desde,hasta,orden,descripcion,index,cantidad);

            List<RemuneracionDTO> remuneracionesDTOs = new();

            foreach (var remu in remuneraciones)
            {
                var DTOremuneracion = _RemuneracionMapper.GenerarRemuneracionDTO(remu);
                remuneracionesDTOs.Add(DTOremuneracion);
            }

            return remuneracionesDTOs;
        }
    }
}
