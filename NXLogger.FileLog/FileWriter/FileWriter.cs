﻿using System;

namespace NXLogger.FileLog.FileWriter
{
    public sealed class FileWriter : IFileWriter
    {
        private readonly IFileWriterWrapper _fileWriterWrapper;

        public FileWriter(IFileWriterWrapper fileWriterWrapper)
        {
            _fileWriterWrapper = fileWriterWrapper;
        }

        public void Write(string path, string message)
        {
            _fileWriterWrapper.Write(path, message);
        }
    }
}
