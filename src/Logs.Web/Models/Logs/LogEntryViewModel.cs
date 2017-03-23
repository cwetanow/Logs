using System;
using System.Collections.Generic;
using System.Linq;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class LogEntryViewModel
    {
        public static Func<LogEntry, string, LogEntryViewModel> FromEntry
        {
            get
            {
                return (entry, userId) => new LogEntryViewModel
                {
                    EntryDate = entry.EntryDate,
                    Content = entry.Content,
                    EntryId = entry.LogEntryId,
                    CanEdit = entry.Log.User?.Id.Equals(userId) ?? false,
                    Comments = entry.Comments.Select(c => CommentViewModel.FromComment(c, userId))
                };
            }
        }

        public bool CanEdit { get; set; }

        public int EntryId { get; set; }

        public DateTime EntryDate { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public string Content { get; set; }
    }
}