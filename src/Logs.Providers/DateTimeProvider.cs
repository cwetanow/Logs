using System;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetTimeFromCurrentTime(int hours, int minutes, int seconds)
        {
            var timeSpan = new TimeSpan(hours, minutes, seconds);

            return DateTime.UtcNow.Add(timeSpan);
        }
    }
}
