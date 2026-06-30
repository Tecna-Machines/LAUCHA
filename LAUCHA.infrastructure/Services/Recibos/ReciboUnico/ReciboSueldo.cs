using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Feriados.GetFeriadoMes;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.infrastructure.Services.Recibos.ReciboUnico
{
    internal class ReciboSueldo
    {
        public GetLiquidacionByIdResponse Liquidacion { get; }
        public GetEmpleadoAsistenciasResponse? Asistencias { get; private set; }
        public GetFeriadosMesResponse? Feriados { get; private set; }
        public bool IncluirSueldoInterno { get; private set; } = false;

        public ReciboSueldo(GetLiquidacionByIdResponse liquidacion)
        {
            Liquidacion = liquidacion;
        }

        public void AgregarAsistencias(GetEmpleadoAsistenciasResponse asistencias)
            => Asistencias = asistencias;

        public void AgregarFeriados(GetFeriadosMesResponse feriados)
            => Feriados = feriados;

        public void IncluirTablaInterna()
            => IncluirSueldoInterno = true;
    }
}
