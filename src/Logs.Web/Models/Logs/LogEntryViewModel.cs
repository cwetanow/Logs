using System;
using System.Collections.Generic;
using System.Linq;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class LogEntryViewModel
    {
        public LogEntryViewModel()
        {

        }

        public LogEntryViewModel(LogEntry entry, string userId)
        {
            this.EntryDate = entry.EntryDate;
            this.Content = entry.Content;
            this.EntryId = entry.LogEntryId;
            this.CanEdit = entry.Log.User.Id.Equals(userId);

            this.Comments = entry.Comments
                .Select(c => new CommentViewModel(c, userId));
        }

        public bool CanEdit { get; set; }

        public int EntryId { get; set; }

        public DateTime EntryDate { get; set; }

        public virtual IEnumerable<CommentViewModel> Comments { get; set; }

        public string Content { get; set; }
    }
}