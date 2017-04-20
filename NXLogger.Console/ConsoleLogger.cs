using System;
using NXLogger.Console.Wrappers;
using System.Collections.Generic;
using NXLogger.Console.Exceptions;
using NXLogger.Contracts.Levels;
using NXLogger.Contracts.Exceptions;
using NXLogger.Contracts;
using NXLogger.Core.Providers;
using NXLogger.Core;

namespace NXLogger.Console
{
    public sealed class ConsoleLogger : LoggerBase, ILogger
    {
        private const int MaxMessageLength = 1000;
        private readonly IConsoleWrapper _consoleWrapper;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ConsoleLogger(IConsoleWrapper consoleWrapper, IDateTimeProvider dateTimeProvider)
        {
            _consoleWrapper = consoleWrapper;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Log(LogLevel level, string logMessage)
        {
            if(logMessage.Length > MaxMessageLength)
            {
                throw new LogMessageToLongException();
            }

            var loginfo = GetLogInfo(level);
            string message = $"{_dateTimeProvider.UtcNow} {loginfo.Item1} {logMessage}";
            _consoleWrapper.WriteLine(message, loginfo.Item2);
        }
    }
}
