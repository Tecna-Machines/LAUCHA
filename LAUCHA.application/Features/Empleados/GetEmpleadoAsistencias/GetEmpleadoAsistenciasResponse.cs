namespace LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias
{
    public record GetEmpleadoAsistenciaRequest(string Dni,DateTime Inicio,DateTime Fin);
    public record GetEmpleadoAsistenciasResponse(string Dni,
                                                 string NombreApellido,
                                                 IEnumerable<GetEmpleadoAsistenciaResponse> Asistencias);

    public record GetEmpleadoAsistenciaResponse(DateTime Ingreso, DateTime Egreso, TimeSpan DebeEntrar);
}
