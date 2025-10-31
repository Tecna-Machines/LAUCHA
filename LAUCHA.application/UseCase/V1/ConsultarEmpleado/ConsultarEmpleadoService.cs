using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.Entities;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ConsultarEmpleado
{
    public class ConsultarEmpleadoService : IConsultarEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly ICuentaRepository _CuentaRepository;
        private readonly IAcuerdoRepository _ContratoRepository;
        private readonly EmpleadoMapper _EmpleadoMapper;
        private readonly ILogsApp log;

        public ConsultarEmpleadoService(IGenericRepository<Empleado> empleadoRepository,
                                        ICuentaRepository cuentaRepository,
                                        ILogsApp log,
                                        IAcuerdoRepository contratoRepository)
        {
            _EmpleadoRepository = empleadoRepository;
            _CuentaRepository = cuentaRepository;
            _EmpleadoMapper = new EmpleadoMapper();
            this.log = log;
            _ContratoRepository = contratoRepository;
        }

        public DTOs.EmpleadoDTO.EmpleadoDTO ConsultarUnEmpleado(string dniEmpleado)
        {
            log.LogInformation("se esta consultando el empleado: {dni}", dniEmpleado);

            Empleado? empleadoObenitdo = _EmpleadoRepository.GetById(dniEmpleado);

            if (empleadoObenitdo == null) { throw new NullReferenceException(); }

            Cuenta? cuentaDelEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleadoObenitdo.Dni);

            log.LogInformation("devolviendo informacion del empleado: {emp}", empleadoObenitdo.Nombre);

            return _EmpleadoMapper.GenerarEmpleadoDTO(empleadoObenitdo, cuentaDelEmpleado);
        }

        public List<DTOs.EmpleadoDTO.EmpleadoDTO> ConsultarTodosLosEmpleados()
        {
            IList<Empleado> empleados = _EmpleadoRepository.GetAll();
            List<DTOs.EmpleadoDTO.EmpleadoDTO> empleadoDTOs = new();

            log.LogInformation("recuperando informacion de todos los empleados");

            foreach (var empleado in empleados)
            {
                Cuenta cuentaEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleado.Dni);
                Acuerdo? contrato;

                try
                {
                    contrato = new();/*  _ContratoRepository.GetActual(empleado.Dni);*/
                }
                catch (NullReferenceException)
                {
                    contrato = null;
                }

                DTOs.EmpleadoDTO.EmpleadoDTO empleadoDTO = _EmpleadoMapper.GenerarEmpleadoDTO(empleado, cuentaEmpleado, contrato);
                empleadoDTOs.Add(empleadoDTO);
            }

            return empleadoDTOs;
        }
    }
}
