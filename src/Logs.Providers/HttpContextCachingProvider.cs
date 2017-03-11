using System;
using System.Web;
using System.Web.Caching;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class HttpContextCachingProvider : ICachingProvider
    {
        protected Cache Cache => HttpContext.Current.Cache;

        public void AddItem(string key, object item)
        {
            this.Cache[key] = item;
        }

        public object GetItem(string key)
        {
            return this.Cache.Get(key);
        }

        public void RemoveItem(string key)
        {
            this.Cache.Remove(key);
        }
    }
}
