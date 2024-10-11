using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Users.Command
{
    public class AddNewUserCommand : IRequest<User>
    {
        public string? Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}