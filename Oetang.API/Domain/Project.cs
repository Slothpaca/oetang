namespace Oetang.API.Domain
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly? End { get; set; }
        public List<Consultant> Consultants { get; set; }
    }

    public class CustomerProject : Project
    {
        public Customer Customer { get; set; }
    }
}
