using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index(string name)
        {
            return View();
        }
    }
}