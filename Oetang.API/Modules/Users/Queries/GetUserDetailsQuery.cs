using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Users.Queries
{
    public class GetUserDetailsQuery : IRequest<User>
    {
        public long UserId { get; set; }
    }
}
