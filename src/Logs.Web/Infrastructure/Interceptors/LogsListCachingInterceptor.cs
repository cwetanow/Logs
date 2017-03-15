using Logs.Providers.Contracts;
using Ninject.Extensions.Interception;

namespace Logs.Web.Infrastructure.Interceptors
{
    public class LogsListCachingInterceptor : IInterceptor
    {
        private readonly ICachingProvider cachingProvider;
        private readonly IDateTimeProvider dateTimeProvider;

        public LogsListCachingInterceptor(ICachingProvider cachingProvider, IDateTimeProvider dateTimeProvider)
        {
            this.cachingProvider = cachingProvider;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            var cacheKey = invocation.Request.Method.Name;

            var result = this.cachingProvider.GetItem(cacheKey);

            if (result == null)
            {
                invocation.Proceed();

                result = invocation.ReturnValue;

                var expirationDate = this.dateTimeProvider.GetTimeFromCurrentTime(0, 5, 0);

                this.cachingProvider.AddItem(cacheKey, result, expirationDate);
            }
            else
            {
                invocation.ReturnValue = result;
            }
        }
    }
}