using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;

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
                FechaIngreso = empleado.FechaIngreso,
                FechaAlta = empleado.FechaAlta
            };
        }

        public DTOs.EmpleadoDTO.EmpleadoDTO GenerarEmpleadoDTO(Empleado empleado, Cuenta cuenta)
        {
            return new DTOs.EmpleadoDTO.EmpleadoDTO
            {
                Dni = empleado.Dni,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                FechaIngreso = empleado.FechaIngreso,
                NumeroCuenta = cuenta.NumeroCuenta,
                FechaCreacion = cuenta.FechaCreacion,
                EstadoCuenta = cuenta.EstadoCuenta
            };
        }

        public DTOs.EmpleadoDTO.EmpleadoDTO GenerarEmpleadoDTO(Empleado empleado, Cuenta cuenta, Acuerdo? contrato)
        {
            var contratoDTO = new ContratoResumenDTO();

            if (contrato != null)
            {
                contratoDTO = new ContratoResumenDTO
                {
                    CodigoContrato = contrato.Codigo,
                    DescripcionModalidad = "test",
                    CodigoModalidad = "test"
                };
            }

            return new DTOs.EmpleadoDTO.EmpleadoDTO
            {
                Dni = empleado.Dni,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                FechaIngreso = empleado.FechaIngreso,
                NumeroCuenta = cuenta.NumeroCuenta,
                FechaCreacion = cuenta.FechaCreacion,
                EstadoCuenta = cuenta.EstadoCuenta,
                ContratoResumen = contratoDTO
            };
        }
    }
}
