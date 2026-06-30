using Humanizer;
using LAUCHA.domain.Entities.Asistencias;
using LAUCHA.domain.Entities.Feriados;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class CalculadoraHorasEspeciales
    {
        private readonly IAsistenciasSource _asistencia;
        private readonly IFeriadoRepository _feriados;

        public CalculadoraHorasEspeciales(IAsistenciasSource asistencia,
                                          IFeriadoRepository feriados)
        {
            _asistencia = asistencia;
            _feriados = feriados;
        }

        public async Task<ItemLiquidacion> GenerarItemHorasExtra(Liquidacion liq)
        {
            var (inicio, fin) = GetPeriodoLiquidacion(liq);

            var periodoAsistencias = await RecuperarAsistencias(
                liq.DniEmpleado,
                inicio,
                fin
            );

            var valorHorasExtra = liq.Acuerdo.ValorHora * 1.5m;

            var cantHorasExtra = periodoAsistencias.GetHorasExtrasDurantePeriodo();

            decimal monto = cantHorasExtra * valorHorasExtra;

            return ItemLiquidacion.CrearRemunerativoEnNegro(
                $"horas extra {cantHorasExtra} | hora: {valorHorasExtra.ToString("C")}",
                monto
            );
        }

        public async Task<ItemLiquidacion> GenerarItemHorasDoble(Liquidacion liq)
        {
            var (inicio, fin) = GetPeriodoLiquidacion(liq);

            var periodoAsistencias = await RecuperarAsistencias(
                liq.DniEmpleado,
                inicio,
                fin
            );

            var valorHorasDoble = liq.Acuerdo.ValorHora;

            var cantHorasDoble = periodoAsistencias.GetHorasDoblesDuranteElPeriodo();

            decimal monto = cantHorasDoble * valorHorasDoble;

            return ItemLiquidacion.CrearRemunerativoEnNegro(
                $"horas doble {cantHorasDoble} | hora:{valorHorasDoble.ToString("C")}",
                monto
            );
        }

        public async Task<ItemLiquidacion> GenerarItemHorasFeriadoOficial(Liquidacion liq)
        {
            var (inicio, fin) = GetPeriodoLiquidacion(liq);

            //si hay un feriado dentro del periodo le agrega 4 hs ,siempre por mas que no venga el empleado
            var feriados = await _feriados.GetFeriadosDelMes(inicio.Month, inicio.Year);
            int cantFeriados = feriados.Count();
            int hsFeriado = cantFeriados * 4;

            //TODO: ojo aca
            decimal monto = hsFeriado * liq.Acuerdo.ValorSueldoOJornal;


            return ItemLiquidacion.CrearRemunerativo(
                $"horas feriado {hsFeriado}",
                monto
                );
        }

        private static (DateTime Inicio, DateTime Fin) GetPeriodoLiquidacion(Liquidacion liq)
        {
            var anio = liq.Anio;
            var mes = liq.Mes;

            DateTime inicio = new DateTime(anio, mes, 1);
            DateTime ultimoDiaDelMes = new DateTime(
                anio,
                mes,
                DateTime.DaysInMonth(anio, mes)
            );

            if (liq.Acuerdo.TipoSueldo == TipoSueldo.MENSUAL_FIJO)
                return (inicio, ultimoDiaDelMes);

            if (liq.Quincena == 2)
                return (new DateTime(anio, mes, 16), ultimoDiaDelMes);

            return (inicio, new DateTime(anio, mes, 15));
        }

        private async Task<PeriodoAsistencias> RecuperarAsistencias(
            string dni,
            DateTime inicio,
            DateTime fin)
        {
            var asistencias = await _asistencia.GetByDniYPeriodo(dni, inicio, fin);
            var feriados = await _feriados.GetFeriadosDelMes(inicio.Month, inicio.Year);

            return new PeriodoAsistencias(asistencias.ToList(),feriados.ToList());
        }


    }
}
