using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IUnitsOfWork;

namespace LAUCHA.application.UseCase.AgregarEmpleadoNuevo
{
    public class AgregarEmpleadoNuevoService : ICrearEmpleadoService
    {
        private readonly ILogsApp log;
        private readonly IUnitOfWorkEmpleado _unitOfWork;
        private EmpleadoMapper _empleadoMapper;

        public AgregarEmpleadoNuevoService(IUnitOfWorkEmpleado unitOfWork, ILogsApp log)
        {
            _unitOfWork = unitOfWork;
            _empleadoMapper = new EmpleadoMapper();
            this.log = log;
        }

        public EmpleadoDTO CargarNuevoEmpleado(CrearEmpleadoDTO nuevoEmpleado)
        {
            Empleado empleado = _empleadoMapper.GenerarEmpleado(nuevoEmpleado);
            empleado = _unitOfWork.EmpleadoRepository.Insert(empleado);

            DateTime fechaActual = DateTime.Now;

            log.LogInformation("se creo un empleado nuevo, nombre: {name} dni: {dni}", empleado.Nombre, empleado.Dni);

            Cuenta nuevaCuenta = new Cuenta
            {
                NumeroCuenta = $"{empleado.Dni}{fechaActual.Day}",
                FechaCreacion = fechaActual,
                DniEmpleado = empleado.Dni,
                estadoCuenta = true
            };

            nuevaCuenta = _unitOfWork.CuentaRepository.Insert(nuevaCuenta);

            log.LogInformation("se creo la cuenta para el empleado , cuento n: {num}", nuevaCuenta.NumeroCuenta);

            _unitOfWork.Save();

            log.LogInformation("se guardaron los datos del nuevo empleado...");

            return _empleadoMapper.GenerarEmpleadoDTO(empleado, nuevaCuenta);
        }
    }
}
