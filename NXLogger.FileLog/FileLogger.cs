using System;
using NXLogger.Contracts;
using NXLogger.Contracts.Levels;
using NXLogger.Core;

namespace NXLogger.FileLog
{
    public sealed class FileLogger : LoggerBase, ILogger
    {
        public void Log(LogLevel level, string logMessage)
        {
            throw new NotImplementedException();
        }
    }
}
