using System;

namespace NXLogger.Console.Wrappers
{
    public interface IConsoleWrapper
    {
        void WriteLine(string message, ConsoleColor color);
    }
}
