using NLog;

namespace XCore.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = (ILogger)LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => LoggerManager.logger.Debug(message);

        public void LogError(string message) => LoggerManager.logger.Error(message);

        public void LogInfo(string message) => LoggerManager.logger.Info(message);

        public void LogWarn(string message) => LoggerManager.logger.Warn(message);
    }
}
