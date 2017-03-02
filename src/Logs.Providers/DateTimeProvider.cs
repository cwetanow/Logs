using System;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrenTime()
        {
            return DateTime.Now;
        }
    }
}
