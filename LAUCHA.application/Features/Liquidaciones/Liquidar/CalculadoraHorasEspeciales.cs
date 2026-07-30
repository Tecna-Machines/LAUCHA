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

            return ItemLiquidacion.CrearRemunerativoInterno(
                $"Horas extras: [{cantHorasExtra}]  Valor hora: {valorHorasExtra.ToString("C")}",
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

            return ItemLiquidacion.CrearRemunerativoInterno(
                $"Horas dobles: [{cantHorasDoble}]  Valor hora:{valorHorasDoble.ToString("C")}",
                monto
            );
        }

        public async Task<ItemLiquidacion> GenerarItemHorasFeriadoOficial(
            Liquidacion liq)
        {
            var (inicio, fin) = GetPeriodoLiquidacion(liq);

            ICollection<Feriado> feriadosDelMes =
                await _feriados.GetFeriadosDelMes(
                    inicio.Month,
                    inicio.Year);

            DateOnly fechaInicio =
                DateOnly.FromDateTime(inicio);

            DateOnly fechaFin =
                DateOnly.FromDateTime(fin);

            int cantidadFeriados = feriadosDelMes.Count(feriado =>
            {
                DateOnly fechaFeriado =
                    DateOnly.FromDateTime(feriado.Fecha);

                return fechaFeriado >= fechaInicio &&
                       fechaFeriado <= fechaFin;
            });


            int jornadaFeriado = 9;

            if (liq.Acuerdo.Jornada == domain.Enums.Jornada.MEDIA)
                jornadaFeriado = 4;

            int horasFeriado = cantidadFeriados * jornadaFeriado;

            decimal monto =
                horasFeriado *
                liq.Acuerdo.ValorSueldoOJornal;

            return ItemLiquidacion.CrearRemunerativo(
                $"Horas feriado ({horasFeriado})",
                monto);
        }

        private static (DateTime Inicio, DateTime Fin) GetPeriodoLiquidacion(Liquidacion liq)
        {
            int anio = liq.Anio;
            int mes = liq.Mes;

            DateTime primerDiaDelMes = new(anio, mes, 1);
            DateTime ultimoDiaDelMes = new(
                anio,
                mes,
                DateTime.DaysInMonth(anio, mes)
            );

            // Los empleados mensuales siempre usan todas las marcas del mes.
            if (liq.Acuerdo.TipoSueldo == TipoSueldo.MENSUAL_FIJO)
            {
                return (primerDiaDelMes, ultimoDiaDelMes);
            }

            // Los empleados quincenales usan solamente las marcas
            // correspondientes a la quincena liquidada.
            return liq.Quincena switch
            {
                1 => (
                    primerDiaDelMes,
                    new DateTime(anio, mes, 15)
                ),

                2 => (
                    new DateTime(anio, mes, 16),
                    ultimoDiaDelMes
                ),

                _ => throw new InvalidOperationException(
                    $"La quincena '{liq.Quincena}' no es válida para la liquidación."
                )
            };
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
