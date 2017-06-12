using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface ISubscriptionService
    {
        bool Subscribe(int logId, string userId);

        bool Unsubscribe(int logId, string userId);

        bool IsSubscribed(int logId, string userId);

        Subscription GetSubscription(int logId, string userId);
    }
}
