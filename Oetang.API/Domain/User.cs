namespace Oetang.API.Domain
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public List<string> Roles { get; set; }
    }
}
