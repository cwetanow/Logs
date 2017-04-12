using System.Web.Mvc;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = Common.Constants.AdministratorRoleName)]
    public class AdministrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}