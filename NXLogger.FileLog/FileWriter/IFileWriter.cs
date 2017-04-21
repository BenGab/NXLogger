using System.Threading.Tasks;

namespace NXLogger.FileLog.FileWriter
{
    public interface IFileWriter
    {
        void Write(string path, string message);

        Task WriteAsync(string path, string message);
    }
}
