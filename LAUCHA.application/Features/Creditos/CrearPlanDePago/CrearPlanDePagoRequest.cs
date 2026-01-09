namespace LAUCHA.application.Features.Creditos.CrearPlanDePago
{
    public record CrearPlanDePagoRequest(int QuincenaInicio,
                                         int MesInicio,
                                         int AnioInicio,
                                         int CantCuotas);

    public record CrearPlanDePagoResponse(string CodigoCredito);
}
