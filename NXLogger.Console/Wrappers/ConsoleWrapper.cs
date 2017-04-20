using System;

namespace NXLogger.Console.Wrappers
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string message, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }
    }
}
