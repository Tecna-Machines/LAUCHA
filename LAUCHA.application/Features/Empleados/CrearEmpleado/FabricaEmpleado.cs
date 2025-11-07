using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    internal class FabricaEmpleado : IFabricaEmpleado
    {
        public Task<Empleado> Crear(CrearEmpleadoRequest req)
        {
            Empleado empleado = new Empleado();

            empleado.Dni = req.Dni;
            empleado.FechaNacimiento = req.FechaNacimiento;
            empleado.FechaAlta = req.FechaAlta;
            empleado.FechaIngreso = req.FechaIngreso;
        }
    }
}
