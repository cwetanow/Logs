using System.Web.Mvc;
using Logs.Common;

namespace Logs.Web.Infrastructure.Attributes
{
    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.Controller.TempData[Constants.ModelState] = filterContext.Controller.ViewData.ModelState;
        }
    }
}