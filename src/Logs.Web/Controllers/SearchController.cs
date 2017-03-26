using System;
using System.Linq;
using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Logs.Web.Models.Search;

namespace Logs.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUserService userService;
        private readonly ILogService logService;
        private readonly IViewModelFactory viewModelFactory;

        public SearchController(IUserService userService, ILogService logService, IViewModelFactory viewModelFactory)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (logService == null)
            {
                throw new ArgumentNullException(nameof(logService));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.logService = logService;
            this.viewModelFactory = viewModelFactory;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public PartialViewResult Search(SearchViewModel model)
        {
            var results = this.logService.Search(model.SearchTerm)
                .Select(this.viewModelFactory.CreateShortLogViewModel);

            return this.PartialView("_LogListPartial", results);
        }
    }
}