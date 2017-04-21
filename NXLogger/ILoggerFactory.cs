using NXLogger.Console.Wrappers;
using NXLogger.Contracts;
using NXLogger.FileLog.FileWriter;
using NXLogger.StreamLog.StreamWriter;
using System.IO;

namespace NXLogger
{
    public interface ILoggerFactory
    {
        ILogger CreateConsoleLogger(IConsoleWrapper consoleWrapper);

        ILogger CreateFileLogger(IFilePathProvider filepathProvider, IFileWriter fileWriter);

        ILogger CreateStreamLogger(Stream stream, IStreamWriter streamWriter);
    }
}
