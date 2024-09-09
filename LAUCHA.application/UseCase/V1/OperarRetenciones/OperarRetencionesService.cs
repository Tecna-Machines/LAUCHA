using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.OperarRetenciones
{
    public class OperarRetencionesService : IOperarRetencionService
    {
        private readonly IGenericRepository<Retencion> _RetencionRepository;
        private readonly IRetencionRepository _RetencionRepositoryEspecifo;
        private readonly RetencionMapper _RetencionMapper;
        private readonly ILogsApp log;
        public OperarRetencionesService(IGenericRepository<Retencion> retencionRepository,
                                        IRetencionRepository retencionRepositoryEspecifo,
                                        ILogsApp log)
        {
            _RetencionRepository = retencionRepository;
            _RetencionMapper = new();
            _RetencionRepositoryEspecifo = retencionRepositoryEspecifo;
            this.log = log;
        }

        public RetencionDTO CrearRetencion(CrearRetencionDTO nuevaRetencionDTO)
        {
            log.LogInformation("generando nueva retencion, cuenta:{c}, desc: {descp} , monto: {mont}",
                               nuevaRetencionDTO.NumeroCuenta, nuevaRetencionDTO.Descripcion, nuevaRetencionDTO.Monto);

            Retencion nuevaRetencion = _RetencionMapper.GenerarRetencion(nuevaRetencionDTO);

            nuevaRetencion = _RetencionRepository.Insert(nuevaRetencion);
            _RetencionRepository.Save();

            log.LogInformation("se genero la nueva retencion con el codigo: {c}", nuevaRetencion.CodigoRetencion);
            return _RetencionMapper.GenerarRetencionDTO(nuevaRetencion);
        }

        public RetencionDTO ConsultarRetencion(string codigoRetencion)
        {
            Retencion retenionEncontrada = _RetencionRepository.GetById(codigoRetencion);

            return _RetencionMapper.GenerarRetencionDTO(retenionEncontrada);
        }

        public async Task<PaginaDTO<RetencionDTO>> ObtenerRetenciones(string? numeroCuenta,
                                                              DateTime? desde,
                                                              DateTime? hasta,
                                                              string? orden,
                                                              string? descripcion,
                                                              int indexPagina,
                                                              int cantidadRegistros)
        {

            log.LogInformation("consultando las retenciones de la cuenta: {c}", numeroCuenta ?? "no cuenta");

            PaginaRegistro<Retencion> pagina = await _RetencionRepositoryEspecifo.ObtenerRetencionesFiltradas(numeroCuenta,
                                                                                                              desde,
                                                                                                              hasta,
                                                                                                              orden,
                                                                                                              descripcion,
                                                                                                              indexPagina,
                                                                                                              cantidadRegistros);
            List<RetencionDTO> retencionesDTO = new();
            List<Retencion> retencionePagina = pagina.Registros;

            foreach (var retencion in retencionePagina)
            {
                var retencionDTO = _RetencionMapper.GenerarRetencionDTO(retencion);
                retencionesDTO.Add(retencionDTO);
            }

            return new PaginaDTO<RetencionDTO>
            {
                Index = pagina.indicePagina,
                TotalEncontrados = pagina.totalRegistros,
                Paginas = pagina.totalPaginas,
                Resultados = retencionesDTO
            };
        }
    }
}
