namespace LAUCHA.application.Features.Liquidaciones.GetLiquidaciones
{
    public sealed record GetLiquidacionesRequest(int Quincena, int Mes, int Anio);
    public sealed record GetLiquidacionesResponse(int Total, IEnumerable<LiquidacionResumenResponse> Liquidaciones);
    public sealed record LiquidacionResumenResponse(string Codigo,
                                                    string Concepto,
                                                    string DniEmpleado,
                                                    string NombreEmpleado,
                                                    DateTime Creacion,
                                                    DateTime Sello,
                                                    bool SeSello);
}
