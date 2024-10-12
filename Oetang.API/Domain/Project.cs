namespace Oetang.API.Domain
{
    public class Project
    {
        // Define all properties.
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
        private List<Consultant> _consultants = new List<Consultant>();
        public IReadOnlyCollection<Consultant> Consultants => _consultants;
        public Customer? Customer { get; set; }
    }
}
