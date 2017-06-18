using Logs.Models;

namespace Logs.Factories
{
    public interface ISubscriptionFactory
    {
        Subscription CreateSubscription(int logId, string userId);
    }
}
