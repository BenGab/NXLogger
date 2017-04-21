using System;
using System.IO;
using System.Text;

namespace NXLogger.StreamLog.StreamWriter
{
    public class StreamWriter : IStreamWriter
    {
        public void Writeline(Stream stream, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}
