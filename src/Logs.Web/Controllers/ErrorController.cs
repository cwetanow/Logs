using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class ErrorController : Controller
    {
        [OutputCache(Duration = 60 * 60 * 24)]
        public ActionResult NotFound()
        {
            return this.View();
        }

        [OutputCache(Duration = 60 * 60 * 24)]
        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}