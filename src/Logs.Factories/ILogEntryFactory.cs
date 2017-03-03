using System;
using Logs.Models;

namespace Logs.Factories
{
    public interface ILogEntryFactory
    {
        LogEntry CreateLogEntry(string content, DateTime entryDate);
    }
}
