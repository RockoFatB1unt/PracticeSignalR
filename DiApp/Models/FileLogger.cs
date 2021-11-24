using DiApp.Interfaces;
using Microsoft.Extensions.Logging;

namespace DiApp.Models
{
    public class FileLogger : IAppLogger
    {
        private readonly ILogger _logger;

        public FileLogger()
        {
        }

        public FileLogger(ILogger<object> logger)
        {
            _logger = logger;
        }

        public void LogMessage(string info)
        {
            _logger.LogInformation(info);
        }
    }
}
