using System;
using System.Text.RegularExpressions;

namespace NXLogger.FileLog.FileWriter
{
    public sealed class FilePathProvider : IFilePathProvider
    {
        /// <summary>
        /// Dummy Implementation. On live enviroment shuld get this path from config file or other area
        /// </summary>
        private const string path = @"C:\log.txt";
        private const long maxFileSize = 5120;
        private readonly IFileInfo _fileInfo;

        public FilePathProvider(IFileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public string GetFilePath()
        {
            string filePath = path;
            long nextNumber = 0;
            Regex rgx = new Regex(@"(\w{1,})\.(\w{1,})");
            while (_fileInfo.GetSize(filePath) >= maxFileSize)
            {
                string replacement = $"$1.{++nextNumber}.$2";
                filePath = rgx.Replace(filePath, replacement);
            }
            return filePath;
        }
    }
}
