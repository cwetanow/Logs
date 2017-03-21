using System;

namespace Logs.Providers.Contracts
{
    public interface ICachingProvider
    {
        void AddItem(string key, object value, DateTime expirationDateTime);

        object GetItem(string key);
    }
}
