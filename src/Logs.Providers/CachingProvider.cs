using System;
using System.Web.Caching;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class CachingProvider : ICachingProvider
    {
        private readonly IHttpContextProvider httpContextProvider;

        public CachingProvider(IHttpContextProvider httpContextProvider)
        {
            this.httpContextProvider = httpContextProvider;
        }

        public void AddItem(string key, object value, DateTime expirationDateTime)
        {
            var context = this.httpContextProvider.CurrentHttpContext;

            context.Cache.Add(key, value, null, expirationDateTime, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        public object GetItem(string key)
        {
            var context = this.httpContextProvider.CurrentHttpContext;

            return context.Cache.Get(key);
        }
    }
}
