using LAUCHA.application.DTOs.PaginaDTOs;
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

        public RemuneracionDTO ConsultarRemuneracion(string codigoRemuneracion)
        {
            Remuneracion remuneracion = _RemuneracionRepository.GetById(codigoRemuneracion);

            if (remuneracion == null) { throw new NullReferenceException(); }

            return _RemuneracionMapper.GenerarRemuneracionDTO(remuneracion);
        }

        public async Task<PaginaDTO<RemuneracionDTO>> ConsultarRemuneracionesFiltradas(string? numeroCuenta,
                                                                     string? descripcion,
                                                                     DateTime? desde,
                                                                     DateTime? hasta,
                                                                     string? orden,
                                                                     int index,
                                                                     int cantidad)
        {
            PaginaRegistro<Remuneracion> pagina = await _RemuneracionRepositoryEspecifico.
                                                 ObtenerRemuneracionesFiltradas(numeroCuenta, desde, hasta, orden, descripcion, index, cantidad);

            List<RemuneracionDTO> remuneracionesDTOs = new();
            List<Remuneracion> remuneraciones = pagina.Registros;

            foreach (var remu in remuneraciones)
            {
                var DTOremuneracion = _RemuneracionMapper.GenerarRemuneracionDTO(remu);
                remuneracionesDTOs.Add(DTOremuneracion);
            }

            return new PaginaDTO<RemuneracionDTO>
            {
                Index = pagina.indicePagina,
                TotalEncontrados = pagina.totalRegistros,
                Paginas = pagina.totalPaginas,
                Resultados = remuneracionesDTOs
            };
        }
    }
}
