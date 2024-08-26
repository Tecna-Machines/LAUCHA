using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.OperacionesDescuento
{
    public class OperarDescuentosService : IOperarDescuentosService
    {
        private readonly IGenericRepository<Descuento> _DescuentoRepository;
        private readonly IGenericRepository<Concepto> _ConceptoRepository;
        private readonly IDescuentoRepository _DescuentoRepositoryEspecifico;
        private readonly DescuentoMapper _DescuentoMapper;
        private readonly ILogsApp log;
        public OperarDescuentosService(IGenericRepository<Descuento> descuentoRepository,
                                       IGenericRepository<Concepto> conceptoRepository,
                                       IDescuentoRepository descuentoRepositoryEspecifico,
                                       ILogsApp log)
        {
            _DescuentoRepository = descuentoRepository;
            _DescuentoMapper = new();
            _ConceptoRepository = conceptoRepository;
            _DescuentoRepositoryEspecifico = descuentoRepositoryEspecifico;
            this.log = log;
        }

        public DescuentoDTO CrearUnDescuentoNuevo(CrearDescuentoDTO nuevoDescuentoDTO)
        {
            log.LogInformation("Se creara el descuento: {des}", nuevoDescuentoDTO.Descripcion);
            log.LogInformation("monto del descuento: {m}", nuevoDescuentoDTO.Monto);

            Descuento nuevo = _DescuentoMapper.CrearDescuento(nuevoDescuentoDTO);
            Concepto? concepto = null;

            _DescuentoRepository.Insert(nuevo);
            _DescuentoRepository.Save();

            if (nuevoDescuentoDTO.NumeroConcepto != null)
            {
                concepto = _ConceptoRepository.GetById(nuevoDescuentoDTO.NumeroConcepto.ToString());
            }

            log.LogInformation("se creo exitosament el descuento");

            return _DescuentoMapper.CrearDescuentoDTO(nuevo, concepto);
        }

        public DescuentoDTO ConsultarUnDescuento(string codigoDescuento)
        {
            Descuento encontrado = _DescuentoRepository.GetById(codigoDescuento);
            Concepto? concepto = null;

            if (encontrado.CodigoDescuento != null)
            {
                concepto = _ConceptoRepository.GetById(encontrado.NumeroConcepto.ToString());
            }
            return _DescuentoMapper.CrearDescuentoDTO(encontrado, concepto);
        }

        public async Task<PaginaDTO<DescuentoDTO>> ConsultarDescuentosFiltrados(string? cuenta,
                                                                                DateTime? desde,
                                                                                DateTime? hasta,
                                                                                string? orden,
                                                                                string? descripcion,
                                                                                int index,
                                                                                int cantidadRegistros)
        {
            PaginaRegistro<Descuento> pagina = await _DescuentoRepositoryEspecifico.
                                                     ObtenerDescuentosFiltrados(cuenta, desde, hasta, orden, descripcion, index, cantidadRegistros);

            List<DescuentoDTO> descuentoDTOs = new();
            List<Descuento> descuentoPagina = pagina.Registros;

            foreach (var descuento in descuentoPagina)
            {
                Concepto? concepto = null;

                if (descuento.NumeroConcepto != null)
                {
                    concepto = _ConceptoRepository.GetById(descuento.NumeroConcepto.ToString());
                }

                var descuentoDTO = _DescuentoMapper.CrearDescuentoDTO(descuento, concepto);
                descuentoDTOs.Add(descuentoDTO);
            }

            return new PaginaDTO<DescuentoDTO>
            {
                Index = pagina.indicePagina,
                TotalEncontrados = pagina.totalRegistros,
                Paginas = pagina.totalPaginas,
                Resultados = descuentoDTOs
            };
        }
    }
}
