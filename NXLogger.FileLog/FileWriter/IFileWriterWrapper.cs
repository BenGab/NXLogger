using System.Threading.Tasks;

namespace NXLogger.FileLog.FileWriter
{
    public interface IFileWriterWrapper
    {
        void Write(string filePath, string message);

        Task WriteAsync(string filePath, string message);
    }
}
