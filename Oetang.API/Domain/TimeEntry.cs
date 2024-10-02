namespace Oetang.API.Domain
{
    public class TimeEntry
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public Project Project { get; set; }
    }
}
