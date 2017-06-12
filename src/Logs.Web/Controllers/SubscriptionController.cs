using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using System;
using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService;
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IViewModelFactory viewModelFactory;

        public SubscriptionController(ISubscriptionService subscriptionService, 
            IAuthenticationProvider authenticationProvider,
            IViewModelFactory viewModelFactory)
        {
            if (subscriptionService == null)
            {
                throw new ArgumentNullException(nameof(subscriptionService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.subscriptionService = subscriptionService;
            this.authenticationProvider = authenticationProvider;
            this.viewModelFactory = viewModelFactory;
        }
    }
}