using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NXLogger.Console.Wrappers;
using NXLogger.Contracts;
using NXLogger.Contracts.Levels;
using NXLogger.Tests.Providers;
using NXLogger.Contracts.Exceptions;
using NXLogger.Console.Exceptions;
using NXLogger.Core.Providers;
using System.Threading.Tasks;

namespace NXLogger.Console.Tests
{
    [TestClass]
    public class ConsoleLoggerTest
    {
        private ILogger _logger;
        private IConsoleWrapper _consoleWrapperMock;
        private IDateTimeProvider _dateTimeProviderMock;

        [TestInitialize]
        public void TestInit()
        {
            _consoleWrapperMock = Substitute.For<IConsoleWrapper>();
            _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
            _dateTimeProviderMock.UtcNow.Returns(DateTime.UtcNow.ToString());
            _logger = new ConsoleLogger(_consoleWrapperMock, _dateTimeProviderMock);
        }

        [TestMethod]
        public void Debug_Level_Log_Should_Log_The_Expected_Message_And_Color()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [DEBUG] {message}";

            _logger.Log(LogLevel.Debug, message);
            _consoleWrapperMock.Received().WriteLine(Arg.Is(expectedMessage), ConsoleColor.Gray);
        }

        [TestMethod]
        public void Info_Level_Log_Should_Log_The_Expected_Message_And_Color()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [INFO] {message}";
            _logger.Log(LogLevel.Info, message);
            _consoleWrapperMock.Received().WriteLine(Arg.Is(expectedMessage), ConsoleColor.Green);
        }

        [TestMethod]
        public void Error_Level_Log_Should_Log_The_Expected_Message_And_Color()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [ERROR] {message}";
            _logger.Log(LogLevel.Error, message);
            _consoleWrapperMock.Received().WriteLine(Arg.Is(expectedMessage), ConsoleColor.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(UnkownLogLevelException))]
        public void Should_Throw_UnkowLogLevelException_On_Unkown_Level()
        {
            _logger.Log((LogLevel)110, LoggerProvider.CreateLogMessage(MessageLength.Large));
        }

        [TestMethod]
        [ExpectedException(typeof(LogMessageToLongException))]
        public void Should_Throw_UnkowLogLevelException_On_ExtraLarge_Message()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.ExtraLarge);
            _logger.Log(LogLevel.Info, message);
        }

        //ASYNC
        [TestMethod]
        public async Task Async_Debug_Level_Log_Should_Log_The_Expected_Message_And_Color()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [DEBUG] {message}";

            await _logger.LogAsync(LogLevel.Debug, message);
            _consoleWrapperMock.Received().WriteLine(Arg.Is(expectedMessage), ConsoleColor.Gray);
        }

        [TestMethod]
        public async Task Async_Info_Level_Log_Should_Log_The_Expected_Message_And_Color()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [INFO] {message}";
            await _logger.LogAsync(LogLevel.Info, message);
            _consoleWrapperMock.Received().WriteLine(Arg.Is(expectedMessage), ConsoleColor.Green);
        }

        [TestMethod]
        public async Task Async_Error_Level_Log_Should_Log_The_Expected_Message_And_Color()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [ERROR] {message}";
            await _logger.LogAsync(LogLevel.Error, message);
            _consoleWrapperMock.Received().WriteLine(Arg.Is(expectedMessage), ConsoleColor.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(UnkownLogLevelException))]
        public async Task Async_Should_Throw_UnkowLogLevelException_On_Unkown_Level()
        {
            await _logger.LogAsync((LogLevel)110, LoggerProvider.CreateLogMessage(MessageLength.Large));
        }

        [TestMethod]
        [ExpectedException(typeof(LogMessageToLongException))]
        public async Task Async_Should_Throw_UnkowLogLevelException_On_ExtraLarge_Message()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.ExtraLarge);
            await _logger.LogAsync(LogLevel.Info, message);
        }
    }
}
