using NXLogger.Contracts.Levels;

namespace NXLogger.Contracts
{
    public interface ILogger
    {
        void Log(LogLevel level, string logMessage);
    }
}
