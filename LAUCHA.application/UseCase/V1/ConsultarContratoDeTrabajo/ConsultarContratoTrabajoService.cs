using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ConsultarContratoDeTrabajo
{
    public class ConsultarContratoTrabajoService : IConsultarContratoTrabajoService
    {
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly IAcuerdoRepository _ContratoRepository;
        private readonly IAcuerdoRepository _ContratoRepositoryEspecifico;
        private readonly IGenericRepository<AcuerdoBlanco> _AcuerdoBlancoRepository;
        private ContratoMapper _ContratoMapper;

        public ConsultarContratoTrabajoService(IGenericRepository<Empleado> empleadoRepository,
                                               IAcuerdoRepository contratoRepository,
                                               IGenericRepository<AcuerdoBlanco> acuerdoBlancoRepository,
                                               IAcuerdoRepository contratoRepositoryEspecifico)
        {
            _EmpleadoRepository = empleadoRepository;
            _ContratoRepository = contratoRepository;
            _AcuerdoBlancoRepository = acuerdoBlancoRepository;
            _ContratoMapper = new ContratoMapper();
            _ContratoRepositoryEspecifico = contratoRepositoryEspecifico;
        }

        public ContratoDTO ConsultarContrato(string codigoContrato)
        {
            Acuerdo contrato = new(); /*_ContratoRepository.GetById(codigoContrato);*/

            if (contrato == null) { throw new NullReferenceException(); }

            Empleado empleado = _EmpleadoRepository.GetById(contrato.DniEmpleado);
            AcuerdoBlanco acuerdoBlanco = _AcuerdoBlancoRepository.GetById(codigoContrato);

            List<Adicional> adicionalesDelContrato = contrato.Adicionales.ToList();

            //TODO: revisar el tipo 
            return _ContratoMapper.GenerarContrato(contrato, TipoSueldo.QuincenalHora, empleado, adicionalesDelContrato, acuerdoBlanco);
        }

        public ContratoDTO ObtenerContratoDeEmpleado(string dniEmpleado)
        {
            Acuerdo? contratoActual = new();/* _ContratoRepositoryEspecifico.GetActual(dniEmpleado);*/

            if (contratoActual == null) { throw new ArgumentNullException(); }

            return ConsultarContrato(contratoActual.Codigo);
        }

        public List<ResumenContratoDTO> ObtenerTodosLosContratosDeEmpleado(string dniEmpleado)
        {
            List<Acuerdo> contratosOriginales = new(); /*_ContratoRepositoryEspecifico.GetHistorial(dniEmpleado);*/
            List<ResumenContratoDTO> contratosResumidos = new List<ResumenContratoDTO>();

            foreach (var contratoOriginal in contratosOriginales)
            {
                var contratoMapeado = new ResumenContratoDTO
                {
                    Codigo = contratoOriginal.Codigo,
                    Fecha = contratoOriginal.Fecha.ToString("dd-MM-yyyy"),
                    MontoFijo = contratoOriginal.Sueldo,
                    MontoHora = contratoOriginal.ValorHora
                };

                contratosResumidos.Add(contratoMapeado);
            }

            return contratosResumidos;

            throw new NotImplementedException();
        }
    }
}
