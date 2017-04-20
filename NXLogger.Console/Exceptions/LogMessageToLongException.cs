using System;

namespace NXLogger.Console.Exceptions
{
    public class LogMessageToLongException : Exception
    {
        public LogMessageToLongException()
            :base("Log Message length is over 1000 characters.")
        {

        }
    }
}
