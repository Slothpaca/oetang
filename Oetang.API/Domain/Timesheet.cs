namespace Oetang.API.Domain
{
    public class Timesheet
    {
        public long Id { get; set; }

        public Consultant Consultant { get; set; }

        public DateOnly Start { get; set; }

        public DateOnly End { get; set; }

        public TimesheetStatus Status { get; set; }

        public List<TimeEntry> Entries { get; set; }

        public List<TimesheetAction> Actions { get; set; }
    }
}
