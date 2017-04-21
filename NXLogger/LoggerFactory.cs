using System;
using NXLogger.Contracts;
using NXLogger.Console;
using NXLogger.Core.Providers;
using NXLogger.Console.Wrappers;
using NXLogger.FileLog;
using NXLogger.FileLog.FileWriter;
using NXLogger.StreamLog;
using System.IO;
using NXLogger.StreamLog.StreamWriter;

namespace NXLogger
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public LoggerFactory(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public ILogger CreateConsoleLogger(IConsoleWrapper consoleWrapper)
        {
            return new ConsoleLogger(consoleWrapper, _dateTimeProvider);
        }

        public ILogger CreateFileLogger(IFilePathProvider filepathProvider, IFileWriter fileWriter)
        {
            return new FileLogger(_dateTimeProvider, filepathProvider, fileWriter);
        }

        public ILogger CreateStreamLogger(Stream stream, IStreamWriter streamWriter)
        {
            return new StreamLogger(stream, _dateTimeProvider, streamWriter);
        }
    }
}
