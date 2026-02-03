using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    public interface IReciboRenderer
    {
        byte[] Render(GetLiquidacionByIdResponse liquidacion);

        byte[] Render(GetLiquidacionByIdResponse liquidacion, GetEmpleadoAsistenciasResponse asistencias);
    }
}
