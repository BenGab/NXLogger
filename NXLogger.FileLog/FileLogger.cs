using System;
using System.Threading.Tasks;
using NXLogger.Contracts;
using NXLogger.Contracts.Levels;
using NXLogger.Core;
using NXLogger.Core.Providers;
using NXLogger.FileLog.FileWriter;

namespace NXLogger.FileLog
{
    public sealed class FileLogger : LoggerBase, ILogger
    {
        private readonly IFilePathProvider _filePathProvider;
        private readonly IFileWriter _fileWriter;

        public FileLogger(IDateTimeProvider dateTimeProvider, IFilePathProvider filePathProvider, IFileWriter fileWriter)
            : base(dateTimeProvider)
        {
            _filePathProvider = filePathProvider;
            _fileWriter = fileWriter;
        }

        public void Log(LogLevel level, string logMessage)
        {
            string path = _filePathProvider.GetFilePath();
            var logInfo = GetLogInfo(level);
            string message = GetMessage(logInfo.Item1, logMessage, _dateTimeProvider.UtcNow);
            _fileWriter.Write(path, message);
        }

        public Task LogAsync(LogLevel level, string logMessage)
        {
            string path = _filePathProvider.GetFilePath();
            var logInfo = GetLogInfo(level);
            string message = GetMessage(logInfo.Item1, logMessage, _dateTimeProvider.UtcNow);
            return _fileWriter.WriteAsync(path, message);
        }
    }
}
