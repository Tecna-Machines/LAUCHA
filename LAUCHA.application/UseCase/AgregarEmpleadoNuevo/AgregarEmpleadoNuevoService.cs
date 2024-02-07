using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.AgregarEmpleadoNuevo
{
    public class AgregarEmpleadoNuevoService : ICrearEmpleadoService
    {
        private readonly IUnitOfWorkEmpleado _unitOfWork;
        private EmpleadoMapper _empleadoMapper;

        public AgregarEmpleadoNuevoService(IUnitOfWorkEmpleado unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _empleadoMapper = new EmpleadoMapper();
        }

        public EmpleadoDTO CargarNuevoEmpleado(CrearEmpleadoDTO nuevoEmpleado)
        {
            Empleado empleado = _empleadoMapper.GenerarEmpleado(nuevoEmpleado);
            empleado = _unitOfWork.EmpleadoRepository.Insert(empleado);

            DateTime fechaActual = DateTime.Now;

            Cuenta nuevaCuenta = new Cuenta
            {
                NumeroCuenta = $"{empleado.Dni}{fechaActual.Day}",
                FechaCreacion = fechaActual,
                DniEmpleado = empleado.Dni,
                estadoCuenta = true
            };

            nuevaCuenta = _unitOfWork.CuentaRepository.Insert(nuevaCuenta);

            _unitOfWork.Save();

            return _empleadoMapper.GenerarEmpleadoDTO(empleado,nuevaCuenta);
        }
    }
}
