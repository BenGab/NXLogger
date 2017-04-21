using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NXLogger.Contracts.Levels;
using NXLogger.Core.Providers;
using NXLogger.StreamLog.StreamWriter;
using NXLogger.Tests.Providers;
using System;
using System.IO;

namespace NXLogger.StreamLog.Tests
{
    [TestClass]
    public class StreamLoggerTests
    {
        private IStreamFactory _streamFactoryMock;
        private IDateTimeProvider _dateTimeProviderMock;
        private IStreamWriter _streamWriterMock;

        [TestInitialize]
        public void TestInititalize()
        {
            _streamFactoryMock = Substitute.For<IStreamFactory>();
            _streamFactoryMock.Create().Returns(new MemoryStream());
            _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
            _dateTimeProviderMock.UtcNow.Returns(DateTime.UtcNow.ToString());
            _streamWriterMock = Substitute.For<IStreamWriter>();
        }

        [TestMethod]
        public void Debug_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [DEBUG] {message}";
            using (var stream = _streamFactoryMock.Create())
            {
                var streamLogger = new StreamLogger(stream, _dateTimeProviderMock, _streamWriterMock);
                streamLogger.Log(LogLevel.Debug, message);
                _streamWriterMock.Received().Writeline(Arg.Any<Stream>(), Arg.Is(expectedMessage));
            }
        }

        [TestMethod]
        public void Info_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [INFO] {message}";
            using (var stream = _streamFactoryMock.Create())
            {
                var streamLogger = new StreamLogger(stream, _dateTimeProviderMock, _streamWriterMock);
                streamLogger.Log(LogLevel.Info, message);
                _streamWriterMock.Received().Writeline(Arg.Any<Stream>(), Arg.Is(expectedMessage));
            }
        }

        [TestMethod]
        public void Error_Log_Call_Shoould_Write_File_Expected_Message__And_Path()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Normal);
            string expectedMessage = $"{_dateTimeProviderMock.UtcNow} [ERROR] {message}";
            using (var stream = _streamFactoryMock.Create())
            {
                var streamLogger = new StreamLogger(stream, _dateTimeProviderMock, _streamWriterMock);
                streamLogger.Log(LogLevel.Error, message);
                _streamWriterMock.Received().Writeline(Arg.Any<Stream>(), Arg.Is(expectedMessage));
            }
        }
    }
}
