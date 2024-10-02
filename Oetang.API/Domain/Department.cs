namespace Oetang.API.Domain
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public User Manager { get; set; }
    }
}
