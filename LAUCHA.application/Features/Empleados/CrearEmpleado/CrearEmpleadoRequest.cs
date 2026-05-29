namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    public record CrearEmpleadoRequest(string Dni,
                                         string Cuil,
                                         string Nombre,
                                         string Apellido,
                                         DateTime FechaIngreso,
                                         DateTime FechaNacimiento,
                                         DateTime FechaAlta);

    public record CrearEmpleadoResponse(string Dni,
                                          string Nombre,
                                          string Apellido);

}
