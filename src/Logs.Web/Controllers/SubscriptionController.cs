using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using System;
using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    [Authorize]
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

        [HttpPost]
        public ActionResult Subscribe(int logId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var isSubscribed = this.subscriptionService.Subscribe(logId, userId);

            var model = this.viewModelFactory.CreateSubscribeViewModel(isSubscribed);

            return this.PartialView("_SubscriptionPartial", model);
        }

        [HttpPost]
        public ActionResult Unsubscribe(int logId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var isUnsubscribed = this.subscriptionService.Unsubscribe(logId, userId);
            var isSubscribed = !isUnsubscribed;

            var model = this.viewModelFactory.CreateSubscribeViewModel(isSubscribed);

            return this.PartialView("_SubscriptionPartial", model);
        }

        public ActionResult Subscription(int logId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var isSubscribed = this.subscriptionService.Unsubscribe(logId, userId);

            var model = this.viewModelFactory.CreateSubscribeViewModel(isSubscribed);

            return this.PartialView("_SubscriptionPartial", model);
        }
    }
}