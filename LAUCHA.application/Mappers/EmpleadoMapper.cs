using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EmpleadoDTO GenerarEmpleadoDTO(Empleado empleado,Cuenta cuenta)
        {
            return new EmpleadoDTO
            {
                Dni = empleado.Dni,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                FechaIngreso = empleado.FechaIngreso,
                NumeroCuento = cuenta.NumeroCuenta,
                FechaCreacion = cuenta.FechaCreacion,
                EstadoCuenta = cuenta.estadoCuenta
            };
        }
    }
}
