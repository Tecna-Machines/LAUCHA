namespace LAUCHA.application.Features.Creditos.GetCredito
{
    public interface IGetCredito
    {
        Task<Result<GetCreditoResponse>> Get(string codigo);
    }
}
