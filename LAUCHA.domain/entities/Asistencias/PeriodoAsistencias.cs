using LAUCHA.domain.Entities.Feriados;

namespace LAUCHA.domain.Entities.Asistencias
{
    public class PeriodoAsistencias
    {
        private List<Asistencia> _asistencias;
        private List<Feriado> _feriados;

        public IReadOnlyCollection<Asistencia> Asistencias => _asistencias.AsReadOnly();
        public DateTimeOffset? Inicio { get; }
        public DateTimeOffset? Fin { get; }

        public PeriodoAsistencias(ICollection<Asistencia> asistencias,
                                  List<Feriado> feriados)
        {
            _asistencias = asistencias.ToList();
            _feriados = feriados;

            MarcarAsistenciasDeDiasFeriados();

            Inicio = GetFechaInicio();
            Fin = GetFechaFin();
        }

        public decimal GetHorasExtrasDurantePeriodo()
            => _asistencias.Sum(a => a.GetHorasExtras());

        public decimal GetHorasTotalesPeriodo()
            => _asistencias.Sum(a => a.GetHorasTotales());

        public decimal GetHorasLaboralesPeriodo()
            => _asistencias.Sum(a => a.GetHorasComunes());

        public decimal GetHorasDoblesDuranteElPeriodo()
            => _asistencias.Sum(a => a.GetHorasDoble());

        public decimal GetHorasFeriado()
        {
            return _asistencias
                .Where(EsAsistenciaDeDiaFeriado)
                .Sum(a => a.GetHorasTotales());
        }

        private void MarcarAsistenciasDeDiasFeriados()
        {
            foreach (var asistencia in _asistencias)
            {
                if (EsAsistenciaDeDiaFeriado(asistencia))
                    asistencia.MarcarComoFeriado();
            }
        }

        private bool EsAsistenciaDeDiaFeriado(Asistencia asistencia)
        {
            if (!asistencia.Ingreso.HasValue)
                return false;

            var fechaAsistencia = ConvertirBuenosAires(asistencia.Ingreso.Value).Date;

            return _feriados.Any(f =>
                ObtenerFechaFeriado(f) == fechaAsistencia
            );
        }

        private static DateTime ObtenerFechaFeriado(Feriado feriado)
        {
            return feriado.Fecha.Date;
        }

        private static DateTime ConvertirBuenosAires(DateTimeOffset utc)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById(
                OperatingSystem.IsWindows()
                    ? "Argentina Standard Time"
                    : "America/Argentina/Buenos_Aires"
            );

            return TimeZoneInfo.ConvertTime(utc, zone).DateTime;
        }

        private DateTimeOffset? GetFechaInicio()
        {
            return _asistencias
                .Where(a => a.Ingreso.HasValue)
                .Select(a => a.Ingreso)
                .DefaultIfEmpty(null)
                .Min();
        }

        private DateTimeOffset? GetFechaFin()
        {
            var maxEgreso = _asistencias
                .Where(a => a.Egreso.HasValue)
                .Select(a => a.Egreso)
                .DefaultIfEmpty(null)
                .Max();

            if (maxEgreso.HasValue)
                return maxEgreso;

            return _asistencias
                .Where(a => a.Ingreso.HasValue)
                .Select(a => a.Ingreso)
                .DefaultIfEmpty(null)
                .Max();
        }
    }
}
