using log4net;

namespace Utilities.Log
{
    public class Logger : ILogger
    {
        protected ILog monitoringLogger;
        protected ILog debugLogger;

        public Logger()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        public void Debug(string message)
        {
            debugLogger.Debug(message);
        }

        public void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(message, exception);
        }

        public void Info(string message)
        {
            monitoringLogger.Info(message);
        }

        public void Info(string message, System.Exception exception)
        {
            monitoringLogger.Info(message, exception);
        }

        public void Warn(string message)
        {
            monitoringLogger.Warn(message);
        }

        public void Warn(string message, System.Exception exception)
        {
            monitoringLogger.Warn(message, exception);
        }

        public void Error(string message)
        {
            monitoringLogger.Error(message);
        }

        public void Error(string message, System.Exception exception)
        {
            monitoringLogger.Error(message, exception);
        }

        public void Fatal(string message)
        {
            monitoringLogger.Fatal(message);
        }

        public void Fatal(string message, System.Exception exception)
        {
            monitoringLogger.Fatal(message, exception);
        }
    }
}
