using DiApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DiApp.Controllers
{
    public class LogController : Controller
    {
        private AppLogger _appLogger;
        private readonly IServiceProvider _serviceProvider;
        public LogController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SaveLogToDb()
        {

            var specificLogger = _serviceProvider.GetService(typeof(ILogger<LogController>)) as ILogger<LogController>;

            _appLogger = new AppLogger(new DbLogger(specificLogger));
            try
            {

            }
            catch (Exception ex)
            {
                _appLogger.LogException(ex);
            }
        }

        public void WriteLogToTextFile()
        {
            var specificLogger = _serviceProvider.GetService(typeof(ILogger<LogController>)) as ILogger<LogController>;

            _appLogger = new AppLogger(new FileLogger(specificLogger));
            try
            {

            }
            catch (Exception ex)
            {
                _appLogger.LogException(ex);

            }
        }
    }
}
