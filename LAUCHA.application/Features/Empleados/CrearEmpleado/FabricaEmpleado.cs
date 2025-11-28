using LAUCHA.domain.entities;

namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    internal class FabricaEmpleado : IFabricaEmpleado
    {
        public Empleado Crear(CrearEmpleadoRequest req)
        {
            Empleado empleado = new Empleado();

            empleado.Dni = req.Dni;
            empleado.Nombre = req.Nombre;
            empleado.Apellido = req.Apellido;
            empleado.FechaNacimiento = req.FechaNacimiento;
            empleado.FechaAlta = req.FechaAlta;
            empleado.FechaIngreso = req.FechaIngreso;
            empleado.Cuenta = new Cuenta(empleado);

            return empleado;
        }

    }
}
