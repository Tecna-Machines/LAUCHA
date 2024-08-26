using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.domain.entities;

namespace LAUCHA.application.Mappers
{
    internal class EmpleadoMapper
    {
        public Empleado GenerarEmpleado(CrearEmpleadoDTO empleado)
        {
            return new Empleado
            {
                Dni = empleado.Dni,
                Apellido = empleado.Apellido,
                Nombre = empleado.Nombre,
                FechaNacimiento = empleado.FechaNacimiento,
                FechaIngreso = empleado.FechaIngreso
            };
        }

        public EmpleadoDTO GenerarEmpleadoDTO(Empleado empleado, Cuenta cuenta)
        {
            return new EmpleadoDTO
            {
                Dni = empleado.Dni,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                FechaIngreso = empleado.FechaIngreso,
                NumeroCuenta = cuenta.NumeroCuenta,
                FechaCreacion = cuenta.FechaCreacion,
                EstadoCuenta = cuenta.estadoCuenta
            };
        }
    }
}
