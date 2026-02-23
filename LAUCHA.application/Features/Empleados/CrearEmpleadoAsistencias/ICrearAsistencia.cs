namespace LAUCHA.application.Features.Empleados.CrearEmpleadoAsistencias
{
    public interface ICrearAsistencia
    {
        Task<Result<CrearEmpleadoAsistenciaResponse>> Crear(CrearEmpleadoAsistenciaRequest req);
    }
}
