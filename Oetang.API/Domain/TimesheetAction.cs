namespace Oetang.API.Domain
{
    public class TimesheetAction
    {
        public long Id { get; set; }

        public string? Comment { get; set; }

        public User User { get; set; }

        public DateTime Timestamp { get; set; }

        public TimesheetActionType Type { get; set; }
        public static TimesheetAction Opened(User user)
        {
            return new TimesheetAction(user, TimesheetActionType.Opened, null);
        }
        // deze constructor is private door de dinge die hierboven staat, deze wordt niet direct aangeroepen, wel hetgeen hierboven.
        private TimesheetAction(User user, TimesheetActionType type, string? comment)
        {
            User = user;
            Type = type;
            Comment = comment;
            Timestamp = DateTime.Now;
        }
        private TimesheetAction()
        {
            
        }
    }
}
