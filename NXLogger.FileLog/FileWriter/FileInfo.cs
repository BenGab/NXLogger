using System.IO;

namespace NXLogger.FileLog.FileWriter
{
    public sealed class FileInfo : IFileInfo
    {
        public long GetSize(string path)
        {
            if (!File.Exists(path))
            {
                return 0;
            }

            return new System.IO.FileInfo(path).Length;
        }
    }
}
