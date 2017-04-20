using System;
using System.IO;

namespace NXLogger.FileLog.FileWriter
{
    public sealed class FileWriterWrapper : IFileWriterWrapper
    {
        public void Write(string filePath, string message)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(message);
                }
            }
        }
    }
}
