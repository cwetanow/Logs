using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Web.Models.Home;

namespace Logs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationProvider provider;

        public HomeController(IAuthenticationProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            this.provider = provider;
        }

        public ActionResult Index()
        {
            var isAuthenticated = this.provider.IsAuthenticated;

            var model = new HomeViewModel { IsAuthenticated = isAuthenticated };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}