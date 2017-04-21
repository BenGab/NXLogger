using System.IO;

namespace NXLogger.StreamLog.StreamWriter
{
    public interface IStreamWriter
    {
        void Writeline(Stream stream, string message);
    }
}
