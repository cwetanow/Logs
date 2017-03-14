using System.Web.Mvc;
using Logs.Web.Models.Upload;

namespace Logs.Web.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return this.View(new UploadViewModel());
        }

        [HttpPost]
        public ActionResult Index(UploadViewModel model)
        {
            return null;
        }
    }
}