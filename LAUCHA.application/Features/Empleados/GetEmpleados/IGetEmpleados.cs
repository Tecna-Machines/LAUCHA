using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Empleados.GetEmpleados
{
    public interface IGetEmpleados
    {
        Task<Result<GetEmpleadosResponse>> GetEmpleados();
    }
}
