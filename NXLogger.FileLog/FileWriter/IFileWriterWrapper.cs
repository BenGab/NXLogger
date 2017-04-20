namespace NXLogger.FileLog.FileWriter
{
    public interface IFileWriterWrapper
    {
        void Write(string filePath, string message);
    }
}
