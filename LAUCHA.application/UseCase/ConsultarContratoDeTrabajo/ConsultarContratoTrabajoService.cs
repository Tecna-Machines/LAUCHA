using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ConsultarContratoDeTrabajo
{
    public class ConsultarContratoTrabajoService : IConsultarContratoTrabajoService
    {
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly IGenericRepository<Contrato> _ContratoRepository;
        private readonly IContratoRepository _ContratoRepositoryEspecifico;
        private readonly IGenericRepository<ModalidadPorContrato> _ModalidadPorContratoRepository;
        private readonly IGenericRepository<Modalidad> _ModalidadRepository;
        private readonly IGenericRepository<Adicional> _AdicionalRepository;
        private readonly IGenericRepository<AcuerdoBlanco> _AcuerdoBlancoRepository;
        private readonly IAdicionalesPorContratoRepository _AdicionalesPorContratoRepository;
        private ContratoMapper _ContratoMapper;

        public ConsultarContratoTrabajoService(IGenericRepository<Empleado> empleadoRepository,
                                               IGenericRepository<Contrato> contratoRepository,
                                               IGenericRepository<Modalidad> modalidadRepository,
                                               IGenericRepository<Adicional> adicionalRepository,
                                               IGenericRepository<AcuerdoBlanco> acuerdoBlancoRepository,
                                               IGenericRepository<ModalidadPorContrato> modalidadPorContratoRepository,
                                               IAdicionalesPorContratoRepository adicionalesPorContratoRepository,
                                               IContratoRepository contratoRepositoryEspecifico)
        {
            _EmpleadoRepository = empleadoRepository;
            _ContratoRepository = contratoRepository;
            _ModalidadRepository = modalidadRepository;
            _AdicionalRepository = adicionalRepository;
            _AcuerdoBlancoRepository = acuerdoBlancoRepository;
            _ModalidadPorContratoRepository = modalidadPorContratoRepository;
            _ContratoMapper = new ContratoMapper();
            _AdicionalesPorContratoRepository = adicionalesPorContratoRepository;
            _ContratoRepositoryEspecifico = contratoRepositoryEspecifico;
        }

        public ContratoDTO ConsultarContrato(string codigoContrato)
        {
            Contrato contratoEncontrado = _ContratoRepository.GetById(codigoContrato);

            if (contratoEncontrado == null) { throw new NullReferenceException(); }

            ModalidadPorContrato modalidadPorContrato = _ModalidadPorContratoRepository.GetById(codigoContrato);
            Modalidad modalidad = _ModalidadRepository.GetById(modalidadPorContrato.CodigoModalidad);
            Empleado empleado = _EmpleadoRepository.GetById(contratoEncontrado.DniEmpleado);
            AcuerdoBlanco acuerdoBlanco = _AcuerdoBlancoRepository.GetById(codigoContrato);

            List<AdicionalPorContrato> adicionalesRecuperados = _AdicionalesPorContratoRepository.ObtenerAdicionalesSegunContrato(codigoContrato);
            List<Adicional> adicionalesDelContrato = new List<Adicional>();

            foreach (var adicional in adicionalesRecuperados)
            {
                var adicionalDelContrato = _AdicionalRepository.GetById(adicional.CodigoAdicional);
                adicionalesDelContrato.Add(adicionalDelContrato);

            }
            //TODO: reemplantar filtrados con repositorios 

            return _ContratoMapper.GenerarContrato(contratoEncontrado, modalidad, empleado, adicionalesDelContrato, acuerdoBlanco);
        }

        public ContratoDTO ObtenerContratoDeEmpleado(string dniEmpleado)
        {
            Contrato? contratoActual = _ContratoRepositoryEspecifico.ObtenerContratoDeEmpleado(dniEmpleado);

            if (contratoActual == null) { throw new ArgumentNullException(); }

            return ConsultarContrato(contratoActual.CodigoContrato);
        }

        public List<ResumenContratoDTO> ObtenerTodosLosContratosDeEmpleado(string dniEmpleado)
        {
            List<Contrato> contratosOriginales = _ContratoRepositoryEspecifico.ObtenerContratosDeEmpleado(dniEmpleado);
            List<ResumenContratoDTO> contratosResumidos = new List<ResumenContratoDTO>();

            foreach (var contratoOriginal in contratosOriginales)
            {
                var contratoMapeado = new ResumenContratoDTO
                {
                    Codigo = contratoOriginal.CodigoContrato,
                    Fecha = contratoOriginal.FechaContrato.ToString("dd-MM-yyyy"),
                    MontoFijo = contratoOriginal.MontoFijo,
                    MontoHora = contratoOriginal.MontoPorHora
                };

                contratosResumidos.Add(contratoMapeado);
            }

            return contratosResumidos;
        }
    }
}
