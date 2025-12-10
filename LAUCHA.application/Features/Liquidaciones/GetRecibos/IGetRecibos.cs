namespace LAUCHA.application.Features.Liquidaciones.GetRecibos
{
    public interface IGetRecibos
    {
        Task<Result<GetRecibosResponse>> Get(GetRecibosRequest req);
    }
}
