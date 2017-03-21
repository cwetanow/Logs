namespace Logs.Providers.Contracts
{
    public interface ICachingProvider
    {
        void AddItem(string key, object value);

        object GetItem(string key);
    }
}
