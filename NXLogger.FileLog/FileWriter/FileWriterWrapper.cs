using System;
using System.IO;
using System.Threading.Tasks;

namespace NXLogger.FileLog.FileWriter
{
    public sealed class FileWriterWrapper : IFileWriterWrapper
    {
        public void Write(string filePath, string message)
        {
            var content = GetFileContent(filePath);
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(content + message);
                    writer.Flush();
                }
            }
        }

        public async Task WriteAsync(string filePath, string message)
        {
            var content = GetFileContent(filePath);
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    await writer.WriteLineAsync(content + message).ConfigureAwait(false);
                    await writer.FlushAsync().ConfigureAwait(false);
                }
            }
        }

        private string GetFileContent(string path)
        {
            if(!File.Exists(path))
            {
                return string.Empty;
            }

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader rdr = new StreamReader(fs))
                {
                    return rdr.ReadToEnd();
                }
            }
        }
    }
}
