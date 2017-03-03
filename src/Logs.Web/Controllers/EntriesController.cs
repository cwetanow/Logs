using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Models.Entries;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IEntryService entryService;

        public EntriesController(IEntryService entryService)
        {
            this.entryService = entryService;
        }

        public ActionResult NewEntry(NewEntryViewModel model)
        {
            this.entryService.AddEntryToLog(model.Content, model.LogId);

            return null;
        }
    }
}