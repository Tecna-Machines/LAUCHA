namespace LAUCHA.application.Features.Feriados.GetFeriadoMes
{
    public interface IGetFeriadosMes
    {
        Task<Result<GetFeriadosMesResponse>> Get(int mes, int anio);
    }
}
