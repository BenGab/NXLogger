using NXLogger.Contracts.Levels;
using System;

namespace NXLogger.Contracts.Exceptions
{
    public class UnkownLogLevelException : Exception
    {
        public UnkownLogLevelException(LogLevel logLevel)
            : base($"Unkown log level: {logLevel}")
        {

        }
    }
}
