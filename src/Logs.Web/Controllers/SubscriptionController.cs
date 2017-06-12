using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using System;
using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService;
        private readonly IAuthenticationProvider authenticationProvider;

        public SubscriptionController(ISubscriptionService subscriptionService, IAuthenticationProvider authenticationProvider)
        {
            if (subscriptionService == null)
            {
                throw new ArgumentNullException(nameof(subscriptionService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            this.subscriptionService = subscriptionService;
            this.authenticationProvider = authenticationProvider;
        }
    }
}