using System.Web.Mvc;
using Logs.Common;

namespace Logs.Web.Infrastructure.Attributes
{
    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.Controller.TempData.ContainsKey(Constants.ModelState))
            {
                filterContext.Controller.ViewData.ModelState.Merge(
                    (ModelStateDictionary)filterContext.Controller.TempData[Constants.ModelState]);
            }
        }
    }
}