using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult NotFound()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}