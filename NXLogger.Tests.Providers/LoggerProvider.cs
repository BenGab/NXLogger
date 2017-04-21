using System;
using System.IO;
using System.Linq;

namespace NXLogger.Tests.Providers
{

    public enum MessageLength
    {
        Small = 50,
        Normal = 80,
        Large = 120,
        ExtraLarge = 1001
    }

    public static class LoggerProvider
    {
        private static Random rnd = new Random();
        public static string CreateLogMessage(MessageLength length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, (int)length).Select(s => s[rnd.Next(chars.Length)]).ToArray());
        }

        public static string GetStreamContent(Stream content)
        {
            content.Flush();
            content.Seek(0, SeekOrigin.Begin);
            using (StreamReader rdr = new StreamReader(content))
            {
                return rdr.ReadToEnd();
            }
        }
    }
}
