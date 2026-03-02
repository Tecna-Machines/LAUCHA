using LAUCHA.domain.Entities.Asistencias;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class CalculadorasHorasExtra
    {
        private readonly IAsistenciasSource _asistencia;

        public CalculadorasHorasExtra(IAsistenciasSource asistencia)
        {
            _asistencia = asistencia;
        }

        public async Task<ItemLiquidacion> GenerarItemHorasExtra(Liquidacion liq)
        {
            var anio = liq.Anio;
            var mes = liq.Mes;

            DateTime inicio = new DateTime(anio, mes, 1);

            DateTime ultimoDiaDelMes = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));

            DateTime fin;

            if (liq.Acuerdo.TipoSueldo == TipoSueldo.Mensual)
            {
                fin = ultimoDiaDelMes;
            }
            else
            {
                if (liq.Quincena == 2)
                {
                    inicio = new DateTime(anio, mes, 16);
                    fin = ultimoDiaDelMes;
                }
                else
                {
                    fin = new DateTime(anio, mes, 15);
                }
            }

            var periodoAsistencias = await RecuperarAsistencias(liq.DniEmpleado, inicio, fin);


            var valorHorasExtra = liq.Acuerdo.ValorHora * 1.5m;

            var cantHorasExtra = periodoAsistencias.GetHorasExtrasDurantePeriodo();
            decimal monto = cantHorasExtra * valorHorasExtra;

            return ItemLiquidacion.CrearRemunerativoEnNegro($"horas extra {cantHorasExtra}", monto);
        }

        private async Task<PeriodoAsistencias> RecuperarAsistencias(string dni, DateTime inicio, DateTime fin)
        {
            var asistencias = await _asistencia.GetByDniYPeriodo(dni, inicio, fin);

            return new PeriodoAsistencias(asistencias.ToList());
        }


    }
}
