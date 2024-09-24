using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.domain.entities;

namespace LAUCHA.application.Mappers
{
    internal class EmpleadoMapper
    {
        public domain.entities.Empleado GenerarEmpleado(CrearEmpleadoDTO empleado)
        {
            return new domain.entities.Empleado
            {
                Dni = empleado.Dni,
                Apellido = empleado.Apellido,
                Nombre = empleado.Nombre,
                FechaNacimiento = empleado.FechaNacimiento,
                FechaIngreso = empleado.FechaIngreso
            };
        }

        public DTOs.EmpleadoDTO.EmpleadoDTO GenerarEmpleadoDTO(domain.entities.Empleado empleado, Cuenta cuenta)
        {
            return new DTOs.EmpleadoDTO.EmpleadoDTO
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

        public DTOs.EmpleadoDTO.EmpleadoDTO GenerarEmpleadoDTO(domain.entities.Empleado empleado, Cuenta cuenta,Contrato? contrato)
        {
            var contratoDTO = new ContratoResumenDTO();

            if(contrato != null)
            {
                contratoDTO = new ContratoResumenDTO
                {
                    CodigoContrato = contrato.CodigoContrato,
                    DescripcionModalidad = contrato.ModalidadesPorContratos.First().Modalidad.Descripcion,
                    CodigoModalidad = contrato.ModalidadesPorContratos.First().Modalidad.CodigoModalidad
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
                EstadoCuenta = cuenta.estadoCuenta,
                ContratoResumen = contratoDTO
            };
        }
    }
}
