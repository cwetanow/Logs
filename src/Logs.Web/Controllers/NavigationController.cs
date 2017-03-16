using System.Web.Mvc;
using Logs.Web.Models.Navigation;

namespace Logs.Web.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult Index()
        {
            var model = new NavigationViewModel();
            return this.PartialView("Navigation", model);
        }
    }
}
