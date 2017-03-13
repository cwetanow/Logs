using System;
using System.Web;
using System.Web.Caching;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class HttpContextCachingProvider : ICachingProvider
    {
        protected Cache Cache => HttpContext.Current.Cache;

        public void AddItem(string key, object item, DateTime expirationDateTime)
        {
            this.Cache.Add(key, item, null, expirationDateTime, Cache.NoSlidingExpiration, CacheItemPriority.Default,
                null);
        }

        public object GetItem(string key)
        {
            return this.Cache.Get(key);
        }
    }
}
