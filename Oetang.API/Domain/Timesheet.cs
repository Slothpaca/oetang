namespace Oetang.API.Domain
{
    public class Timesheet
    {
        // Define all properties.
        public long Id { get; set; }

        public Consultant Consultant { get; set; }

        public DateOnly Start { get; set; }

        public DateOnly End { get; set; }

        public TimesheetStatus Status { get; set; }

        public List<TimeEntry> Entries { get; set; }

        public List<TimesheetAction> Actions { get; set; }
        public Timesheet(Consultant consultant, DateOnly startDate, DateOnly endDate, User departmentManager)
        {
            Consultant = consultant;
            Start = startDate;
            End = endDate;
            Status = TimesheetStatus.Open; //Default open bij aanmaken
            Entries = new List<TimeEntry>();
            //Actions = new List<TimesheetAction>();
            //Actions.Add(new TimesheetAction(departmentManager, TimesheetActionType.Opened, null));
            // Bovenstaande wordt hieronder versimpeld.
            Actions = [TimesheetAction.Opened(departmentManager)];
        }
        private Timesheet()
        {
            
        }
    }
}
