namespace LAUCHA.domain.Entities.Asistencias
{
    public class Asistencia
    {
        public string DniEmpleado { get; private set; } = string.Empty;

        public DateTimeOffset? Ingreso { get; private set; }
        public DateTimeOffset? Egreso { get; private set; }
        public TimeSpan DebeIngresar { get; private set; }

        private const decimal JORNADA_HORAS = 9m;
        private bool _esFeriado;
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

        public void MarcarComoFeriado()
        {
            _esFeriado = true;
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

        private bool EsSabado()
        {
            if (!Ingreso.HasValue)
                return false;

            var ingresoLocal = ConvertirBuenosAiresUTC(Ingreso.Value);
            return ingresoLocal.DayOfWeek == DayOfWeek.Saturday;
        }

        public bool EsFeriado()
        {
            return _esFeriado;
        }

        public decimal GetHorasComunes()
        {
            var total = GetHorasTotales();
            if (total <= 0)
                return 0m;

            if (EsFeriado())
                return 0m;

            if (EsSabado())
                return 0m;

            return Math.Min(total, JORNADA_HORAS);
        }
        public decimal GetHorasExtras()
        {
            var total = GetHorasTotales();

            if (total <= 0)
                return 0m;

            const decimal QUINCE_MINUTOS = 0; //0.25m;
            const decimal HORAS_SABADO_SIMPLES = 6m;



            if (EsSabado())
            {
                var hsExtraSabado = Math.Min(total, HORAS_SABADO_SIMPLES);
                hsExtraSabado = Math.Round(hsExtraSabado, 2);

                return hsExtraSabado > QUINCE_MINUTOS ? hsExtraSabado : 0m;
            }

            if (total <= JORNADA_HORAS)
                return 0m;

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

        public decimal GetHorasDoble()
        {
            var total = GetHorasTotales();

            if (total <= 0)
                return 0m;

            const decimal QUINCE_MINUTOS = 0m; // o 0.25m 

            if (EsFeriado())
            {
                total = Math.Round(total, 2);
                return total > QUINCE_MINUTOS ? total*1.5m : 0m;
            }


            if (!EsSabado())
                return 0m;


            const decimal HORAS_SABADO_SIMPLES = 6m;

            if (total <= HORAS_SABADO_SIMPLES)
                return 0m;

            var hsDoble = Math.Round(total - HORAS_SABADO_SIMPLES, 2);

            return hsDoble > QUINCE_MINUTOS ? hsDoble*2m : 0m;
        }

        private DateTimeOffset GetInicioLaboral()
        {
            var ingresoLocal = ConvertirBuenosAiresUTC(Ingreso!.Value);

            var debeIngresarLocal = new DateTime(
                ingresoLocal.Year,
                ingresoLocal.Month,
                ingresoLocal.Day,
                DebeIngresar.Hours,
                DebeIngresar.Minutes,
                DebeIngresar.Seconds,
                DateTimeKind.Unspecified
            );

            var debeIngresarUtc = ConvertirTimeOffset(debeIngresarLocal);

            // Si llegó tarde, cuenta desde el ingreso real.
            // Si llegó temprano o a horario, cuenta desde la hora que debía ingresar.
            return Ingreso.Value > debeIngresarUtc
                ? Ingreso.Value
                : debeIngresarUtc;
        }
    }
}
