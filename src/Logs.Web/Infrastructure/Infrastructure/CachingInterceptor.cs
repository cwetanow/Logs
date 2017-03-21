using Logs.Providers.Contracts;
using Ninject.Extensions.Interception;

namespace Logs.Web.Infrastructure.Infrastructure
{
    public class CachingInterceptor : IInterceptor
    {
        private readonly ICachingProvider cachingProvider;

        public CachingInterceptor(ICachingProvider cachingProvider)
        {
            this.cachingProvider = cachingProvider;
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

                this.cachingProvider.AddItem(key, result);
            }
        }
    }
}