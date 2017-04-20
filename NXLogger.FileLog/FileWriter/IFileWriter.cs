namespace NXLogger.FileLog.FileWriter
{
    public interface IFileWriter
    {
        void Write(string path, string message);
    }
}
