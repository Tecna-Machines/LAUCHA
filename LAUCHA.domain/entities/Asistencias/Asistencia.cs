namespace LAUCHA.domain.Entities.Asistencias
{
    public class Asistencia
    {
        public string DniEmpleado { get; private set; } = string.Empty;

        public DateTimeOffset? Ingreso { get; private set; }
        public DateTimeOffset? Egreso { get; private set; }
        public TimeSpan DebeIngresar { get; private set; }

        private const decimal JORNADA_HORAS = 9m;
        protected Asistencia() { }

        public static Asistencia Crear(string dni, DateTime? ingresoBa, DateTime? egresoBa, DateTime? debeIngresarBa)
        {

            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("DNI.vacio", nameof(dni));

            var debe = debeIngresarBa?.TimeOfDay ?? TimeSpan.Zero;

            return new Asistencia
            {
                DniEmpleado = dni.Trim(),
                Ingreso = ingresoBa.HasValue ? ConvertirTimeOffset(ingresoBa.Value) : null,
                Egreso = egresoBa.HasValue ? ConvertirTimeOffset(egresoBa.Value) : null,
                DebeIngresar = debe
            };
        }

        private static DateTimeOffset ConvertirTimeOffset(DateTime localBa)
        {
            var unspecified = DateTime.SpecifyKind(localBa, DateTimeKind.Unspecified);

            var zone = TimeZoneInfo.FindSystemTimeZoneById(
                OperatingSystem.IsWindows()
                    ? "Argentina Standard Time"
                    : "America/Argentina/Buenos_Aires"
            );

            var utc = TimeZoneInfo.ConvertTimeToUtc(unspecified, zone);
            return new DateTimeOffset(utc, TimeSpan.Zero);
        }

        private static DateTimeOffset ConvertirBuenosAiresUTC(DateTimeOffset utc)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById(
                OperatingSystem.IsWindows()
                    ? "Argentina Standard Time"
                    : "America/Argentina/Buenos_Aires"
            );

            return TimeZoneInfo.ConvertTime(utc, zone);
        }

        public decimal GetHorasComunes()
        {
            var total = GetHorasTotales();
            if (total <= 0)
                return 0m;

            return Math.Min(total, JORNADA_HORAS);
        }
        public decimal GetHorasExtras()
        {
            var total = GetHorasTotales();
            if (total <= JORNADA_HORAS)
                return 0m;


            const decimal QUINCE_MINUTOS = 0.25m;

            decimal hsExtra = Math.Round(total - JORNADA_HORAS, 2);

            return hsExtra > QUINCE_MINUTOS ? hsExtra : 0m;
        }

        public decimal GetHorasTotales()
        {
            if (!Ingreso.HasValue || !Egreso.HasValue)
                return 0m;

            var inicioLaboral = GetInicioLaboral();
            if (Egreso <= inicioLaboral)
                return 0m;

            var trabajadas = (Egreso.Value - inicioLaboral).TotalHours;
            return Math.Round((decimal)trabajadas, 2);
        }

        /// <summary>
        /// Devuelve el instante desde el cual empieza a computar horas
        /// a partir de la hora de ingreso
        /// </summary>
        private DateTimeOffset GetInicioLaboral()
        {
            var ingresoLocal = ConvertirBuenosAiresUTC(Ingreso!.Value);

            var inicioLocal = new DateTime(
                ingresoLocal.Year,
                ingresoLocal.Month,
                ingresoLocal.Day,
                DebeIngresar.Hours,
                DebeIngresar.Minutes,
                DebeIngresar.Seconds,
                DateTimeKind.Unspecified
            );

            return ConvertirTimeOffset(inicioLocal);
        }
    }
}
