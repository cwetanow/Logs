using System.Web.Caching;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class CachingProvider : ICachingProvider
    {
        private readonly IHttpContextProvider httpContextProvider;
        private readonly IDateTimeProvider dateTimeProvider;

        public CachingProvider(IHttpContextProvider httpContextProvider, IDateTimeProvider dateTimeProvider)
        {
            this.httpContextProvider = httpContextProvider;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void AddItem(string key, object value)
        {
            var context = this.httpContextProvider.CurrentHttpContext;

            var date = this.dateTimeProvider.GetCurrentTime().AddMinutes(5);

            context.Cache.Add(key, value, null, date, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public object GetItem(string key)
        {
            var context = this.httpContextProvider.CurrentHttpContext;

            return context.Cache.Get(key);
        }
    }
}
