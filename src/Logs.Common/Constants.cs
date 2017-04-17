namespace Logs.Common
{
    public static class Constants
    {
        public const string AdministratorRoleName = "administrator";

        public const int LogEntriesPerPage = 20;
        public const int LogsPerPage = 10;
        public const int TopLogsCount = 3;
        public const int AdminPageSize = 10;

        public const int HoursCaching = 0;
        public const int MinutesCaching = 5;
        public const int SecondsCaching = 0;

        public const string ModelState = "ModelState";

        public const string ShortDateFormat = "{0:D} at {0:HH:mm}";
        public const string WithPostedOnDateFormat = "Posted on {0:D} at {0:HH:mm}";
    }
}
