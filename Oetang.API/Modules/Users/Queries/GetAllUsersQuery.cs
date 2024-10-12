// Include necessary namespaces
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Users.Queries
{
    // GetAllUsersQuery class implements the IRequest interface from MediatR.
    // It represents a query to retrieve a collection (IEnumerable) of User objects.
    // No additional properties are needed for this query since it simply retrieves all users.
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}