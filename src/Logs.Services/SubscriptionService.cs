using System;
using Logs.Services.Contracts;
using Logs.Data.Contracts;
using Logs.Models;
using Logs.Factories;

namespace Logs.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IRepository<Subscription> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubscriptionFactory factory;
        
        public bool IsSubscribed(int logId, string userId)
        {
            throw new NotImplementedException();
        }

        public bool Subscribe(int logId, string userId)
        {
            throw new NotImplementedException();
        }

        public bool Unsubscribe(int logId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
