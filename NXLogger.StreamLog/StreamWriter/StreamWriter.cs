using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NXLogger.StreamLog.StreamWriter
{
    public class StreamWriter : IStreamWriter
    {
        public void Writeline(Stream stream, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }

        public Task WriteLineAsync(Stream stream, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            return stream.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
