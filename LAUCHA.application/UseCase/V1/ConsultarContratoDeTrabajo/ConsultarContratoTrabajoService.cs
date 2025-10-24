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
        private readonly IGenericRepository<AcuerdoBlanco> _AcuerdoBlancoRepository;
        private ContratoMapper _ContratoMapper;

        public ConsultarContratoTrabajoService(IGenericRepository<Empleado> empleadoRepository,
                                               IGenericRepository<Contrato> contratoRepository,
                                               IGenericRepository<Modalidad> modalidadRepository,
                                               IGenericRepository<AcuerdoBlanco> acuerdoBlancoRepository,
                                               IGenericRepository<ModalidadPorContrato> modalidadPorContratoRepository,
                                               IContratoRepository contratoRepositoryEspecifico)
        {
            _EmpleadoRepository = empleadoRepository;
            _ContratoRepository = contratoRepository;
            _ModalidadRepository = modalidadRepository;
            _AcuerdoBlancoRepository = acuerdoBlancoRepository;
            _ModalidadPorContratoRepository = modalidadPorContratoRepository;
            _ContratoMapper = new ContratoMapper();
            _ContratoRepositoryEspecifico = contratoRepositoryEspecifico;
        }

        public ContratoDTO ConsultarContrato(string codigoContrato)
        {
            Contrato contrato = _ContratoRepository.GetById(codigoContrato);

            if (contrato == null) { throw new NullReferenceException(); }

            ModalidadPorContrato modalidadPorContrato = _ModalidadPorContratoRepository.GetById(codigoContrato);
            Modalidad modalidad = _ModalidadRepository.GetById(modalidadPorContrato.CodigoModalidad);
            Empleado empleado = _EmpleadoRepository.GetById(contrato.DniEmpleado);
            AcuerdoBlanco acuerdoBlanco = _AcuerdoBlancoRepository.GetById(codigoContrato);

            List<Adicional> adicionalesDelContrato = contrato.Adicionales.ToList();

            //TODO: reemplantar filtrados con repositorios 

            return _ContratoMapper.GenerarContrato(contrato, modalidad, empleado, adicionalesDelContrato, acuerdoBlanco);
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
