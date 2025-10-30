using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    internal interface ICrearAcuerdo
    {
        Task<Result<CrearAcuerdoResponse>> Crear(CrearAcuerdoRequest req);
    }
}
