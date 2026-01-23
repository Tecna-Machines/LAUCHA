namespace LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias
{
    public interface IGetEmpleadoAsistencias
    {
        Task<Result<GetEmpleadoAsistenciasResponse>> GetAsistencias(GetEmpleadoAsistenciaRequest req);
    }
}
