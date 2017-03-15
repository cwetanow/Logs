using System.Web.Mvc;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "administrator")]
    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}