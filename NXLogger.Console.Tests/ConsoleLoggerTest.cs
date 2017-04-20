using Microsoft.VisualStudio.TestTools.UnitTesting;
using NXLogger.Contracts;
using NXLogger.Console.Wrappers;
using NSubstitute;

namespace NXLogger.Console.Tests
{
    [TestClass]
    public class ConsoleLoggerTest
    {
        private ILogger _logger;
        private IConsoleWrapper _consoleWrapperMock;

        [TestInitialize]
        public void TestInit()
        {
            _consoleWrapperMock = Substitute.For<IConsoleWrapper>();
            _logger = new ConsoleLogger(_consoleWrapperMock);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
