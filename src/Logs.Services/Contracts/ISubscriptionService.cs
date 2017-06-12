namespace Logs.Services.Contracts
{
    public interface ISubscriptionService
    {
        bool Subscribe(int logId, string userId);

        bool Unsubscribe(int logId, string userId);
    }
}
