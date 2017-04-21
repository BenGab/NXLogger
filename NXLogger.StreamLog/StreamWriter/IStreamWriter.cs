using System.IO;
using System.Threading.Tasks;

namespace NXLogger.StreamLog.StreamWriter
{
    public interface IStreamWriter
    {
        void Writeline(Stream stream, string message);

        Task WriteLineAsync(Stream stream, string message);
    }
}
