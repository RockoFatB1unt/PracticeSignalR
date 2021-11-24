using DiApp.Interfaces;
using Microsoft.Extensions.Logging;

namespace DiApp.Models
{
    public class DbLogger : IAppLogger
    {

        private readonly ILogger _logger;

        public DbLogger()
        {
        }

        public DbLogger(ILogger<object> logger)
        {
            _logger = logger;
        }

        public void LogMessage(string info)
        {
            _logger.LogError(info);
        }
    }
}
