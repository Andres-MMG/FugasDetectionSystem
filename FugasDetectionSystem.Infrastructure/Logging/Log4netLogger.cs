using FugasDetectionSystem.Domain.Interfaces;
using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace FugasDetectionSystem.Infrastructure.Logging
{

    public class Log4netLogger : ILogger
    {
        private readonly ILog _log;

        public Log4netLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            _log = LogManager.GetLogger(typeof(Log4netLogger));
        }

        public void LogInfo(string message)
        {
            _log.Info(message);
        }

        public void LogWarning(string message)
        {
            _log.Warn(message);
        }

        public void LogError(string message, Exception ex)
        {
            _log.Error(message, ex);
        }
    }

}
