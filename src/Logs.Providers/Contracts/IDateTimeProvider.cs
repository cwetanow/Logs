using System;

namespace Logs.Providers.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrenTime();
    }
}
