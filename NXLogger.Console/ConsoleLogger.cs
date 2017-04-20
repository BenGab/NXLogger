using System;
using NXLogger.Console.Wrappers;
using NXLogger.Contracts;
using NXLogger.Contracts.Levels;

namespace NXLogger.Console
{
    public class ConsoleLogger : ILogger
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public ConsoleLogger(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public void Log(LogLevel level, string logMessage)
        {
            throw new NotImplementedException();
        }
    }
}
