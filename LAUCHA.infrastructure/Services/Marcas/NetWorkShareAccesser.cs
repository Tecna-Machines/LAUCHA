using System.Diagnostics;

namespace LAUCHA.infrastructure.Services.Marcas
{
    public class NetworkShareAccesser : IDisposable
    {
        private string _networkName;

        public NetworkShareAccesser(string networkName, string username, string password)
        {
            _networkName = networkName;

            var netUseCommand = @$"net use \\{_networkName} /user:{username} {password}";
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + netUseCommand)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = Process.Start(processInfo);
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException($"Failed to access network share: {process.StandardError.ReadToEnd()}");
            }
        }

        public void Dispose()
        {
            var netUseDeleteCommand = $"net use {_networkName} /delete";
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + netUseDeleteCommand)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = Process.Start(processInfo);
            process?.WaitForExit();
        }
    }
}
