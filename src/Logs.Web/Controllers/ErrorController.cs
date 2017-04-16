using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 60 * 60 * 24)]
        public ActionResult NotFound()
        {
            return this.View();
        }

        [HttpGet]
        [OutputCache(Duration = 60 * 60 * 24)]
        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}