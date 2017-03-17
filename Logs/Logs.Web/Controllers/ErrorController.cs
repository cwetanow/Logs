using System.Web.Mvc;

namespace Logs.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}