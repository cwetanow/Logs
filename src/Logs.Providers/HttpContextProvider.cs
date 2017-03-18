using System.Web;
using Logs.Providers.Contracts;

namespace Logs.Providers
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext CurrentHttpContext
        {
            get
            {
                return HttpContext.Current;
            }
        }
    }
}
