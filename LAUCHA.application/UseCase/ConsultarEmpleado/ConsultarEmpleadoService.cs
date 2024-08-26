using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ConsultarEmpleado
{
    public class ConsultarEmpleadoService : IConsultarEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly ICuentaRepository _CuentaRepository;
        private readonly EmpleadoMapper _EmpleadoMapper;
        private readonly ILogsApp log;

        public ConsultarEmpleadoService(IGenericRepository<Empleado> empleadoRepository, ICuentaRepository cuentaRepository, ILogsApp log)
        {
            _EmpleadoRepository = empleadoRepository;
            _CuentaRepository = cuentaRepository;
            _EmpleadoMapper = new EmpleadoMapper();
            this.log = log;
        }

        public EmpleadoDTO ConsultarUnEmpleado(string dniEmpleado)
        {
            log.LogInformation("se esta consultando el empleado: {dni}", dniEmpleado);

            Empleado? empleadoObenitdo = _EmpleadoRepository.GetById(dniEmpleado);

            if(empleadoObenitdo == null) { throw new NullReferenceException(); }

            Cuenta? cuentaDelEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleadoObenitdo.Dni);

            log.LogInformation("devolviendo informacion del empleado: {emp}", empleadoObenitdo.Nombre);

            return _EmpleadoMapper.GenerarEmpleadoDTO(empleadoObenitdo, cuentaDelEmpleado);
        }

        public List<EmpleadoDTO> ConsultarTodosLosEmpleados()
        {
            IList<Empleado> empleados = _EmpleadoRepository.GetAll();
            List<EmpleadoDTO> empleadoDTOs = new();

            log.LogInformation("recuperando informacion de todos los empleados");

            foreach (var empleado in empleados)
            {   
                Cuenta cuentaEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleado.Dni);
                EmpleadoDTO empleadoDTO = _EmpleadoMapper.GenerarEmpleadoDTO(empleado, cuentaEmpleado);
                empleadoDTOs.Add(empleadoDTO);
            }

            return empleadoDTOs;
        }
    }
}
