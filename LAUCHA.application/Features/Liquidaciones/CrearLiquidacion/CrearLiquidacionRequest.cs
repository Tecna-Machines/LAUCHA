namespace LAUCHA.application.Features.Liquidaciones.CrearLiquidacion
{
    public record CrearLiquidacionRequest(string Dni,
                                          int Anio,
                                          int Mes,
                                          int Quincena);

    public record CrearLiquidacionResponse(string Codigo);
}
