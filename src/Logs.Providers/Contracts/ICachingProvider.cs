namespace Logs.Providers.Contracts
{
    public interface ICachingProvider
    {
        void AddItem(string key, object item);

        object GetItem(string key);

        void RemoveItem(string key);
    }
}
