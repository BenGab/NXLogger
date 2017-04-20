using System;
using NXLogger.Console.Wrappers;
using System.Collections.Generic;
using NXLogger.Console.Exceptions;
using NXLogger.Contracts.Levels;
using NXLogger.Contracts.Exceptions;
using NXLogger.Contracts;
using NXLogger.Core.Providers;

namespace NXLogger.Console
{
    public class ConsoleLogger : ILogger
    {
        private const int MaxMessageLength = 1000;
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly Dictionary<LogLevel, Tuple<string, ConsoleColor>> _logInfos = new Dictionary<LogLevel, Tuple<string, ConsoleColor>>
        {
            {LogLevel.Debug, new Tuple<string, ConsoleColor>("[DEBUG]", ConsoleColor.Gray) },
            {LogLevel.Info, new Tuple<string, ConsoleColor>("[INFO]", ConsoleColor.Green) },
            {LogLevel.Error, new Tuple<string, ConsoleColor>("[ERROR]", ConsoleColor.Red) }
        };

        public ConsoleLogger(IConsoleWrapper consoleWrapper, IDateTimeProvider dateTimeProvider)
        {
            _consoleWrapper = consoleWrapper;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Log(LogLevel level, string logMessage)
        {
            if(!_logInfos.ContainsKey(level))
            {
                throw new UnkownLogLevelException(level);
            }

            if(logMessage.Length > MaxMessageLength)
            {
                throw new LogMessageToLongException();
            }

            var loginfo = _logInfos[level];
            string message = $"{_dateTimeProvider.UtcNow} {loginfo.Item1} {logMessage}";
            _consoleWrapper.WriteLine(message, loginfo.Item2);
        }
    }
}
