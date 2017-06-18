using Logs.Services.Contracts;
using Logs.Data.Contracts;
using Logs.Models;
using Logs.Factories;
using System.Linq;
using System;

namespace Logs.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IRepository<Subscription> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubscriptionFactory factory;

        public SubscriptionService(IRepository<Subscription> repository,
            IUnitOfWork unitOfWork,
            ISubscriptionFactory factory)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        public bool IsSubscribed(int logId, string userId)
        {
            var subscription = this.GetSubscription(logId, userId);

            var isSubscribed = subscription != null;

            return isSubscribed;
        }

        public bool Subscribe(int logId, string userId)
        {
            if (!this.IsSubscribed(logId, userId) && !string.IsNullOrEmpty(userId))
            {
                var subscription = this.factory.CreateSubscription(logId, userId);

                this.repository.Add(subscription);
                this.unitOfWork.Commit();

                return true;
            }

            return false;
        }

        public bool Unsubscribe(int logId, string userId)
        {
            var subscription = this.GetSubscription(logId, userId);

            if (subscription != null && !string.IsNullOrEmpty(userId))
            {
                this.repository.Delete(subscription);
                this.unitOfWork.Commit();

                return true;
            }

            return false;
        }

        public Subscription GetSubscription(int logId, string userId)
        {
            var subscription = this.repository.All
                .FirstOrDefault(s => s.TrainingLogId == logId && s.UserId == userId);

            return subscription;
        }
    }
}
