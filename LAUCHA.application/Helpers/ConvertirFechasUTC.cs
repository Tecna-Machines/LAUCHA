namespace LAUCHA.application.Helpers
{
    internal static class ConvertirFechasUTC
    {
        public static DateTime ToBuenosAiresDateTime(DateTimeOffset? value)
        {
            if (!value.HasValue)
                return DateTime.MinValue;

            var zone = TimeZoneInfo.FindSystemTimeZoneById(
                OperatingSystem.IsWindows()
                    ? "Argentina Standard Time"
                    : "America/Argentina/Buenos_Aires"
            );

            var local = TimeZoneInfo.ConvertTime(value.Value, zone);

            return DateTime.SpecifyKind(local.DateTime, DateTimeKind.Unspecified);
        }
    }
}
