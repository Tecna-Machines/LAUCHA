using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    public interface ICrearAcuerdo
    {
        Task<Result<CrearAcuerdoResponse>> Crear(CrearAcuerdoRequest req);
    }
}
