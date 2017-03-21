using System;
using Logs.Providers.Contracts;
using Ninject.Extensions.Interception;

namespace Logs.Web.Infrastructure.Interception
{
    public class CachingInterceptor : IInterceptor
    {
        private readonly ICachingProvider cachingProvider;
        private readonly IDateTimeProvider dateTimeProvider;

        public CachingInterceptor(ICachingProvider cachingProvider, IDateTimeProvider dateTimeProvider)
        {
            if (cachingProvider == null)
            {
                throw new ArgumentNullException(nameof(cachingProvider));
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(nameof(dateTimeProvider));
            }

            this.cachingProvider = cachingProvider;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            var key = invocation.Request.Method.Name;

            var result = this.cachingProvider.GetItem(key);

            if (result != null)
            {
                invocation.ReturnValue = result;
            }
            else
            {
                invocation.Proceed();

                result = invocation.ReturnValue;

                var date = this.dateTimeProvider.GetTimeFromCurrentTime(0, 5, 0);
                this.cachingProvider.AddItem(key, result, date);
            }
        }
    }
}