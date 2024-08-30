using LAUCHA.application.interfaces;
using Serilog;


namespace LAUCHA.infrastructure.Services.Logs
{
    public class LogService : ILogsApp
    {
        private static ILogger? _logger;
        public LogService(string logPathFile)
        {
            _logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .WriteTo.File(logPathFile, rollingInterval: RollingInterval.Day, shared: true)
                        .CreateLogger();

            if (_logger == null) { throw new ArgumentNullException(); }

            _logger.Information($"Logger initialized: file path=> {logPathFile}");
        }
        public void LogError(Exception ex, string message, params object[] properties)
        {
            _logger!.Error(ex, message, properties);
        }

        public void LogError(string message)
        {
            _logger!.Error(message);
        }

        public void LogInformation(string message, params object[] properties)
        {
            _logger!.Information(message, properties);
        }

        public void LogInformation(string message)
        {
            _logger!.Information(message);
        }

        public void LogWarning(string message, params object[] properties)
        {
            _logger!.Warning(message, properties);
        }
    }
}
