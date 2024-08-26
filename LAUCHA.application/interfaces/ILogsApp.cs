namespace LAUCHA.application.interfaces
{
    public interface ILogsApp
    {
        void LogInformation(string message, params object[] properties);
        void LogInformation(string message);
        void LogWarning(string message, params object[] properties);
        void LogError(Exception ex, string message, params object[] properties);
        void LogError(string message);
    }
}
