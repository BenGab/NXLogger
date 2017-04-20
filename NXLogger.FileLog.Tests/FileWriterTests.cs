using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NXLogger.FileLog.FileWriter;

namespace NXLogger.FileLog.Tests
{
    [TestClass]
    public class FileWriterTests
    {
        private IFileWriter _fileWriter;
        private IFileWriterWrapper _fileWriterWrapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _fileWriterWrapperMock = Substitute.For<IFileWriterWrapper>();
            _fileWriter = new FileWriter.FileWriter(_fileWriterWrapperMock);
        }

        [TestMethod]
        public void WriteFile_Should_Write_The_ExpectedMessage_To_Expected_Path()
        {
            const string path = "Path";
            const string message = "Message";

            _fileWriter.Write(path, message);
            _fileWriterWrapperMock.Received().Write(Arg.Is(path), Arg.Is(message));
        }
    }
}
