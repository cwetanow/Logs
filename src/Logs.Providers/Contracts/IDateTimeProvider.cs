using System;

namespace Logs.Providers.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrenTime();

        DateTime GetTimeFromCurrentTime(int hours, int minutes, int seconds);
    }
}
