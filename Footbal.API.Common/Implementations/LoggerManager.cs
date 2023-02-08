using Football.API.Common.Contracts;
using NLog;

namespace Football.API.Common.Implementations
{
    public class LoggerManager: ILoggerManager
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        
        public void LogInfo(string message) => Logger.Info(message);
        public void LogWarn(string message) => Logger.Warn(message);
        public void LogDebug(string message) => Logger.Debug(message);
        public void LogError(string message, string className, int line = 0)
        {
            Logger.Error($"{message} | ClassName: {className} | ErrorLine {line}");
        }
    }
}
