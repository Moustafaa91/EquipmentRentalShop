namespace Utilities.Log
{
    public interface ILogger
    {
        void Debug(string message);

        void Debug(string message, System.Exception exception);

        void Info(string message);

        void Info(string message, System.Exception exception);

        void Warn(string message);

        void Warn(string message, System.Exception exception);

        void Error(string message);

        void Error(string message, System.Exception exception);

        void Fatal(string message);

        void Fatal(string message, System.Exception exception);
    }
}
