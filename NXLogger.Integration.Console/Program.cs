using NXLogger.Console.Wrappers;
using NXLogger.Contracts.Levels;
using NXLogger.Core.Providers;
using NXLogger.FileLog.FileWriter;
using NXLogger.Tests.Providers;
using System;

namespace NXLogger.Integration.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = new LoggerFactory(new DateTimeProvider());
            ConsoleLoggerTest(loggerFactory);
            FileLoggerTest(loggerFactory);

            System.Console.ReadLine();
        }

        private static void ConsoleLoggerTest(LoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateConsoleLogger(new ConsoleWrapper());

            logger.Log(LogLevel.Debug, LoggerProvider.CreateLogMessage(MessageLength.Normal));
            logger.Log(LogLevel.Info, LoggerProvider.CreateLogMessage(MessageLength.Normal));

            try
            {
                logger.Log(LogLevel.Info, LoggerProvider.CreateLogMessage(MessageLength.ExtraLarge));
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
            }
        }

        private static void FileLoggerTest(LoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateFileLogger(new FilePathProvider(new FileInfo()), new FileWriter(new FileWriterWrapper()));
            logger.Log(LogLevel.Debug, LoggerProvider.CreateLogMessage(MessageLength.Normal));
            logger.Log(LogLevel.Info, LoggerProvider.CreateLogMessage(MessageLength.Normal));
            logger.Log(LogLevel.Error, LoggerProvider.CreateLogMessage(MessageLength.Normal));
        }
    }
}