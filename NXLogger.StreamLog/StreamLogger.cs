using NXLogger.Contracts;
using NXLogger.Contracts.Levels;
using NXLogger.Core;
using NXLogger.Core.Providers;
using System.IO;
using NXLogger.StreamLog.StreamWriter;
using System;
using System.Threading.Tasks;

namespace NXLogger.StreamLog
{
    public class StreamLogger : LoggerBase, ILogger
    {
        private readonly Stream _stream;
        private readonly IStreamWriter _streamWriter;

        public StreamLogger(Stream stream, IDateTimeProvider dateTimeProvider, IStreamWriter streamWriter)
            : base(dateTimeProvider)
        {
            _stream = stream;
            _streamWriter = streamWriter;
        }

        public void Log(LogLevel level, string logMessage)
        {
            var logInfo = GetLogInfo(level);
            string message = GetMessage(logInfo.Item1, logMessage, _dateTimeProvider.UtcNow);
            _streamWriter.Writeline(_stream, message);
        }

        public Task LogAsync(LogLevel level, string logMessage)
        {
            var logInfo = GetLogInfo(level);
            string message = GetMessage(logInfo.Item1, logMessage, _dateTimeProvider.UtcNow);
            return _streamWriter.WriteLineAsync(_stream, message);
        }
    }
}
