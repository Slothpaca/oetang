using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}