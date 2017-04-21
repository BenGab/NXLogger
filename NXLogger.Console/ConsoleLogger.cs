using System;
using NXLogger.Console.Wrappers;
using System.Collections.Generic;
using NXLogger.Console.Exceptions;
using NXLogger.Contracts.Levels;
using NXLogger.Contracts.Exceptions;
using NXLogger.Contracts;
using NXLogger.Core.Providers;
using NXLogger.Core;
using System.Threading.Tasks;

namespace NXLogger.Console
{
    public sealed class ConsoleLogger : LoggerBase, ILogger
    {
        private const int MaxMessageLength = 1000;
        private readonly IConsoleWrapper _consoleWrapper;

        public ConsoleLogger(IConsoleWrapper consoleWrapper, IDateTimeProvider dateTimeProvider)
            : base(dateTimeProvider)
        {
            _consoleWrapper = consoleWrapper;
        }

        public void Log(LogLevel level, string logMessage)
        {
            if (logMessage.Length > MaxMessageLength)
            {
                throw new LogMessageToLongException();
            }

            var loginfo = GetLogInfo(level);
            string message = GetMessage(loginfo.Item1, logMessage, _dateTimeProvider.UtcNow);
            _consoleWrapper.WriteLine(message, loginfo.Item2);
        }

        public async Task LogAsync(LogLevel level, string logMessage)
        {
            await Task.Run(() => Log(level, logMessage));
        }
    }
}
