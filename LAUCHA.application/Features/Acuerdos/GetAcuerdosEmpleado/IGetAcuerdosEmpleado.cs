namespace LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado
{
    public interface IGetAcuerdosEmpleado
    {
        Task<Result<GetAcuerdosEmpleadosResponse>> GetAcuerdosEmpleado(GetAcuerdosEmpleadoRequest request);
    }
}
