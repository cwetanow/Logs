using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Web.Infrastructure.Factories;

namespace Logs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationProvider provider;
        private readonly IViewModelFactory factory;

        public HomeController(IAuthenticationProvider provider, IViewModelFactory factory)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.provider = provider;
            this.factory = factory;
        }

        public ActionResult Index()
        {
            var isAuthenticated = this.provider.IsAuthenticated;

            var model = this.factory.CreateHomeViewModel(isAuthenticated);

            return View(model);
        }
    }
}