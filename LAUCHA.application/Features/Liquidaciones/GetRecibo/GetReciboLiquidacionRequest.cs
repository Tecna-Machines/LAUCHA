using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Feriados.GetFeriadoMes;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    public sealed record GetReciboLiquidacionRequest(string Id);

    public sealed record GetReciboLiquidacionResponse(string FileName, string ContentType, byte[] Content);

    //mantiene los datos necesarios para construir el recibo
    public sealed record ReciboRequest(GetLiquidacionByIdResponse Liquidacion,
                                       GetEmpleadoAsistenciasResponse Asistencias,
                                       GetFeriadosMesResponse Feriados);
}
