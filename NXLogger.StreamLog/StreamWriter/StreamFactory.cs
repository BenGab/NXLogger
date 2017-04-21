using System.IO;

namespace NXLogger.StreamLog.StreamWriter
{
    public class StreamFactory : IStreamFactory
    {
        public Stream Create()
        {
           return new MemoryStream();
        }
    }
}
