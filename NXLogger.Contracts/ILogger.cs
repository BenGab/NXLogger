using NXLogger.Contracts.Levels;
using System.Threading.Tasks;

namespace NXLogger.Contracts
{
    public interface ILogger
    {
        void Log(LogLevel level, string logMessage);

        Task LogAsync(LogLevel level, string logMessage);
    }
}
