using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ConsultarEmpleado
{
    public class ConsultarEmpleadoService : IConsultarEmpleadoService
    {
        private readonly IGenericRepository<domain.entities.Empleado> _EmpleadoRepository;
        private readonly ICuentaRepository _CuentaRepository;
        private readonly EmpleadoMapper _EmpleadoMapper;
        private readonly ILogsApp log;

        public ConsultarEmpleadoService(IGenericRepository<domain.entities.Empleado> empleadoRepository, ICuentaRepository cuentaRepository, ILogsApp log)
        {
            _EmpleadoRepository = empleadoRepository;
            _CuentaRepository = cuentaRepository;
            _EmpleadoMapper = new EmpleadoMapper();
            this.log = log;
        }

        public DTOs.EmpleadoDTO.EmpleadoDTO ConsultarUnEmpleado(string dniEmpleado)
        {
            log.LogInformation("se esta consultando el empleado: {dni}", dniEmpleado);

            domain.entities.Empleado? empleadoObenitdo = _EmpleadoRepository.GetById(dniEmpleado);

            if (empleadoObenitdo == null) { throw new NullReferenceException(); }

            Cuenta? cuentaDelEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleadoObenitdo.Dni);

            log.LogInformation("devolviendo informacion del empleado: {emp}", empleadoObenitdo.Nombre);

            return _EmpleadoMapper.GenerarEmpleadoDTO(empleadoObenitdo, cuentaDelEmpleado);
        }

        public List<DTOs.EmpleadoDTO.EmpleadoDTO> ConsultarTodosLosEmpleados()
        {
            IList<domain.entities.Empleado> empleados = _EmpleadoRepository.GetAll();
            List<DTOs.EmpleadoDTO.EmpleadoDTO> empleadoDTOs = new();

            log.LogInformation("recuperando informacion de todos los empleados");

            foreach (var empleado in empleados)
            {
                Cuenta cuentaEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleado.Dni);
                DTOs.EmpleadoDTO.EmpleadoDTO empleadoDTO = _EmpleadoMapper.GenerarEmpleadoDTO(empleado, cuentaEmpleado);
                empleadoDTOs.Add(empleadoDTO);
            }

            return empleadoDTOs;
        }
    }
}
