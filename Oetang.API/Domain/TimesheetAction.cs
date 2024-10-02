namespace Oetang.API.Domain
{
    public abstract class TimesheetAction
    {
        public long Id { get; set; }

        public string? Comment { get; set; }

        public User User { get; set; }

        public DateTime Timestamp { get; set; }
    }

    public class TimesheetOpenedAction : TimesheetAction
    { }

    public class TimesheetSubmittedAction : TimesheetAction
    { }

    public class TimesheetRejectedAction : TimesheetAction
    { }

    public class TimesheetApprovedAction : TimesheetAction
    { }

    public class TimesheetCommentAddedAction : TimesheetAction
    { }

    public class TimesheetEntryAddedAction : TimesheetAction
    {
        public TimeEntry TimeEntry { get; set; }
    }
}
