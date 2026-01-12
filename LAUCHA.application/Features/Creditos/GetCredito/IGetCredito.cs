namespace LAUCHA.application.Features.Creditos.GetCredito
{
    public interface IGetCredito
    {
        Task<Result<GetCreditoByIdResponse>> Get(string codigo);
    }
}
