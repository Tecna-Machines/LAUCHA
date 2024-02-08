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

        public ConsultarEmpleadoService(IGenericRepository<Empleado> empleadoRepository, ICuentaRepository cuentaRepository)
        {
            _EmpleadoRepository = empleadoRepository;
            _CuentaRepository = cuentaRepository;
            _EmpleadoMapper = new EmpleadoMapper();
        }

        public EmpleadoDTO ConsultarUnEmpleado(string dniEmpleado)
        {
            Empleado? empleadoObenitdo = _EmpleadoRepository.GetById(dniEmpleado);

            if(empleadoObenitdo == null) { throw new NullReferenceException(); }

            Cuenta? cuentaDelEmpleado = _CuentaRepository.ObtenerCuentaDelEmpleado(empleadoObenitdo.Dni);

            return _EmpleadoMapper.GenerarEmpleadoDTO(empleadoObenitdo, cuentaDelEmpleado);
        }
    }
}
