using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NXLogger.FileLog.FileWriter;

namespace NXLogger.FileLog.Tests
{
    [TestClass]
    public class FilePathProviderTest
    {
        private IFilePathProvider _filepathProvider;
        private IFileInfo _fileInfoMock;
        private const string expectedFilePath = @"C:\log.txt";

        [TestInitialize]
        public void TestInititalize()
        {
            _fileInfoMock = Substitute.For<IFileInfo>();
            _filepathProvider = new FilePathProvider(_fileInfoMock);
        }

        [TestMethod]
        public void GetFilePath_Should_Return_The_Expected_Path()
        {
            _fileInfoMock.GetSize(Arg.Is(expectedFilePath)).Returns(0);
            var path = _filepathProvider.GetFilePath();
            Assert.AreEqual(path, expectedFilePath);
        }

        [TestMethod]
        public void GetFilePath_Should_Return_The_Expected_Path_With_NextNumber()
        {
            _fileInfoMock.GetSize(Arg.Is(expectedFilePath)).Returns(5120);
            var path = _filepathProvider.GetFilePath();
            var expectedPath = @"C:\log.1.txt";
            Assert.AreEqual(path, expectedPath);
        }
    }
}
