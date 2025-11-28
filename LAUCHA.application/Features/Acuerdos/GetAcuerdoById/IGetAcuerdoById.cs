namespace LAUCHA.application.Features.Acuerdos.GetAcuerdoById
{
    public interface IGetAcuerdoById
    {
        Task<Result<GetAcuerdoByIdResponse>> GetAcuerdo(GetAcuerdoByIdResquest req);
    }
}
