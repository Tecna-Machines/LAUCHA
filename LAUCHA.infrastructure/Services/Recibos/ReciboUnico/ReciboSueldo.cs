using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class ReciboSueldo
    {
        public GetLiquidacionByIdResponse Liquidacion { get; }
        public GetEmpleadoAsistenciasResponse? Asistencias { get; private set; }
        public bool IncluirInterna { get; private set; }

        public ReciboSueldo(GetLiquidacionByIdResponse liquidacion)
        {
            Liquidacion = liquidacion;
        }

        public void AgregarAsistencias(GetEmpleadoAsistenciasResponse asistencias)
            => Asistencias = asistencias;

        public void IncluirTablaInterna()
            => IncluirInterna = true;
    }
}
