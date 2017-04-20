using NXLogger.Contracts.Exceptions;
using NXLogger.Contracts.Levels;
using System;
using System.Collections.Generic;

namespace NXLogger.Core
{
    public abstract class LoggerBase
    {
        private readonly Dictionary<LogLevel, Tuple<string, ConsoleColor>> _logInfos = new Dictionary<LogLevel, Tuple<string, ConsoleColor>>
        {
            {LogLevel.Debug, new Tuple<string, ConsoleColor>("[DEBUG]", ConsoleColor.Gray) },
            {LogLevel.Info, new Tuple<string, ConsoleColor>("[INFO]", ConsoleColor.Green) },
            {LogLevel.Error, new Tuple<string, ConsoleColor>("[ERROR]", ConsoleColor.Red) }
        };

        protected Tuple<string, ConsoleColor> GetLogInfo(LogLevel logLevel)
        {
            if (!_logInfos.ContainsKey(logLevel))
            {
                throw new UnkownLogLevelException(logLevel);
            }

            return _logInfos[logLevel];
        }

        protected string GetMessage(string logInfo, string message, string time)
        {
            return $"{time} {logInfo} {message}";
        }
    }
}
