using LAUCHA.domain.Entities.Feriados;
using LAUCHA.domain.Services.CalendarioLaboral;

namespace LAUCHA.infrastructure.Services.CalendarioLaboral
{
    internal sealed class CalendarioLaboralImp : ICalendarioLaboral
    {
        private readonly IFeriadoRepository _feriados;

        public CalendarioLaboralImp(IFeriadoRepository feriados)
        {
            _feriados = feriados;
        }

        public async Task<int> CalcularDiasHabiles(
            int anio,
            int mes,
            int numeroQuincena)
        {
            ValidarPeriodo(anio, mes, numeroQuincena);

            DateOnly fechaDesde = ObtenerFechaDesde(
                anio,
                mes,
                numeroQuincena);

            DateOnly fechaHasta = ObtenerFechaHasta(
                anio,
                mes,
                numeroQuincena);

            var feriadosDelMes =
                await _feriados.GetFeriadosDelMes(mes, anio);

            HashSet<DateOnly> fechasFeriadas = feriadosDelMes
                .Select(feriado =>
                    DateOnly.FromDateTime(feriado.Fecha))
                .ToHashSet();

            int diasHabiles = 0;

            for (
                DateOnly fecha = fechaDesde;
                fecha <= fechaHasta;
                fecha = fecha.AddDays(1))
            {
                bool esFinDeSemana =
                    fecha.DayOfWeek is DayOfWeek.Saturday
                        or DayOfWeek.Sunday;

                bool esFeriado =
                    fechasFeriadas.Contains(fecha);

                if (!esFinDeSemana && !esFeriado)
                    diasHabiles++;
            }

            return diasHabiles;
        }

        private static DateOnly ObtenerFechaDesde(
            int anio,
            int mes,
            int numeroQuincena)
        {
            int diaDesde = numeroQuincena == 1
                ? 1
                : 16;

            return new DateOnly(anio, mes, diaDesde);
        }

        private static DateOnly ObtenerFechaHasta(
            int anio,
            int mes,
            int numeroQuincena)
        {
            int diaHasta = numeroQuincena == 1
                ? 15
                : DateTime.DaysInMonth(anio, mes);

            return new DateOnly(anio, mes, diaHasta);
        }

        private static void ValidarPeriodo(
            int anio,
            int mes,
            int numeroQuincena)
        {
            if (anio < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(anio),
                    "El año no es válido.");
            }

            if (mes is < 1 or > 12)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(mes),
                    "El mes debe estar entre 1 y 12.");
            }

            if (numeroQuincena is not 1 and not 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(numeroQuincena),
                    "La quincena debe ser 1 o 2.");
            }
        }
    }
}