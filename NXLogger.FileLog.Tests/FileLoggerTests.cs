using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NXLogger.Contracts;
using NXLogger.Contracts.Levels;
using NXLogger.Core.Providers;
using NXLogger.FileLog.FileWriter;
using NXLogger.Tests.Providers;
using System;
using System.Threading.Tasks;

namespace NXLogger.FileLog.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        private ILogger _fileLogger;
        private IDateTimeProvider _dateTimeProviderMock;
        private IFilePathProvider _filePathProviderMock;
        private IFileWriter _filewriterMock;
        private const string expectedFilePath = "dummy";

        [TestInitialize]
        public void TestInititalize()
        {
            _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
            _dateTimeProviderMock.UtcNow.Returns(DateTime.UtcNow.ToString());
            _filePathProviderMock = Substitute.For<IFilePathProvider>();
            _filePathProviderMock.GetFilePath().Returns(expectedFilePath);
            _filewriterMock = Substitute.For<IFileWriter>();
            _fileLogger = new FileLogger(_dateTimeProviderMock, _filePathProviderMock, _filewriterMock);
        }

        [TestMethod]
        public void Debug_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [DEBUG] {message}";
            _fileLogger.Log(LogLevel.Debug, message);
            _filewriterMock.Received().Write(Arg.Is(expectedFilePath), Arg.Is(expectedMessage));
        }

        [TestMethod]
        public void Info_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [INFO] {message}";
            _fileLogger.Log(LogLevel.Info, message);
            _filewriterMock.Received().Write(Arg.Is(expectedFilePath), Arg.Is(expectedMessage));
        }

        [TestMethod]
        public void Error_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [ERROR] {message}";
            _fileLogger.Log(LogLevel.Error, message);
            _filewriterMock.Received().Write(Arg.Is(expectedFilePath), Arg.Is(expectedMessage));
        }

        //Async
        [TestMethod]
        public async Task Async_Debug_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [DEBUG] {message}";
            await _fileLogger.LogAsync(LogLevel.Debug, message);
            await _filewriterMock.Received().WriteAsync(Arg.Is(expectedFilePath), Arg.Is(expectedMessage));
        }

        [TestMethod]
        public async Task Async_Info_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [INFO] {message}";
            await _fileLogger.LogAsync(LogLevel.Info, message);
            await _filewriterMock.Received().WriteAsync(Arg.Is(expectedFilePath), Arg.Is(expectedMessage));
        }

        [TestMethod]
        public async Task Async_Error_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [ERROR] {message}";
            await _fileLogger.LogAsync(LogLevel.Error, message);
            await _filewriterMock.Received().WriteAsync(Arg.Is(expectedFilePath), Arg.Is(expectedMessage));
        }
    }
}
