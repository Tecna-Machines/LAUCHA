namespace LAUCHA.domain.Entities.Asistencias
{
    public class PeriodoAsistencias
    {
        private List<Asistencia> _asistencias;
        public DateTimeOffset? Inicio { get; }
        public DateTimeOffset? Fin { get; }

        public PeriodoAsistencias(ICollection<Asistencia> asistencias)
        {
            _asistencias = asistencias.ToList();

            Inicio = GetFechaInicio();
            Fin = GetFechaFin();
        }

        public decimal GetHorasExtrasDurantePeriodo()
            => _asistencias.Sum(a => a.GetHorasExtras());

        public decimal GetHorasTotalesPeriodo()
            => _asistencias.Sum(a => a.GetHorasTotales());

        public decimal GetHorasLaboralesPeriodo()
            => _asistencias.Sum(a => a.GetHorasComunes());

        private DateTimeOffset? GetFechaInicio()
        {
            return _asistencias
                .Where(a => a.Ingreso.HasValue)
                .Min(a => a.Ingreso);
        }

        private DateTimeOffset? GetFechaFin()
        {
            var maxEgreso = _asistencias
                .Where(a => a.Egreso.HasValue)
                .Max(a => a.Egreso);

            if (maxEgreso.HasValue)
                return maxEgreso;

            return _asistencias
                .Where(a => a.Ingreso.HasValue)
                .Max(a => a.Ingreso);
        }
    }
}
