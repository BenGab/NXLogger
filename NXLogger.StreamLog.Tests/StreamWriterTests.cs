using Microsoft.VisualStudio.TestTools.UnitTesting;
using NXLogger.StreamLog.StreamWriter;
using NXLogger.Tests.Providers;
using System.IO;

namespace NXLogger.StreamLog.Tests
{
    [TestClass]
    public class StreamWriterTests
    {
        private IStreamWriter _streamWriter;

        [TestInitialize]
        public void TestInitialize()
        {
            _streamWriter = new StreamWriter.StreamWriter();
        }

        [TestMethod]
        public void WriteLine_Shoud_Log_To_Stream_The_Expected_Message()
        {
            string message = LoggerProvider.CreateLogMessage(MessageLength.Small);

            using (var stream = new MemoryStream())
            {
                _streamWriter.Writeline(stream, message);
                Assert.AreEqual(message, LoggerProvider.GetStreamContent(stream));
            }
        }
    }
}
