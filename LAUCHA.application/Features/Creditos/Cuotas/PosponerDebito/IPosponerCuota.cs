namespace LAUCHA.application.Features.Creditos.Cuotas.PosponerDebito
{
    public interface IPosponerCuota
    {
        Task<Result<PosponerCuotaResponse>> Posponer(PosponerCuotaRequest req);
    }
}
