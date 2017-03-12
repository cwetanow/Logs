using System.Diagnostics;
using Logs.Providers.Contracts;
using Ninject.Extensions.Interception;

namespace Logs.Web.Infrastructure.Interceptors
{
    public class CachingInterceptor : IInterceptor
    {
        private const string InterceptedMethodName = "GetAllSortedByDate";
        private const string InterceptedRemoveCacheMethodName = "CreateTrainingLog";

        private readonly ICachingProvider cachingProvider;

        public CachingInterceptor(ICachingProvider cachingProvider)
        {
            this.cachingProvider = cachingProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Request.Method.Name.Equals(InterceptedMethodName))
            {
                var result = this.cachingProvider.GetItem(InterceptedMethodName);

                if (result == null)
                {
                    invocation.Proceed();

                    result = invocation.ReturnValue;

                    this.cachingProvider.AddItem(InterceptedMethodName, result);
                }
                else
                {
                    invocation.ReturnValue = result;
                }

                return;
            }
            else if (invocation.Request.Method.Name.Equals(InterceptedRemoveCacheMethodName))
            {
                invocation.Proceed();
                var result = invocation.ReturnValue;

                if (result != null)
                {
                    this.cachingProvider.RemoveItem(InterceptedMethodName);
                }
            }

            invocation.Proceed();
        }
    }
}