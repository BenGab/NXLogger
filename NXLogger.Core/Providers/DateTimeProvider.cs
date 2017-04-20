using System;

namespace NXLogger.Core.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public string UtcNow => DateTime.UtcNow.ToString();
    }
}
