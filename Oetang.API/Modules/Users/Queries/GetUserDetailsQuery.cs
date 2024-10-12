// Include necessary namespaces
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Users.Queries
{
    // GetUserDetailsQuery class implements the IRequest interface from MediatR.
    // This class represents a query to retrieve detailed information of a specific user.
    public class GetUserDetailsQuery : IRequest<User>
    {
        // Property to hold the ID of the user whose details are being requested.
        // This ID will be provided when the query is executed.
        public long UserId { get; set; }
    }
}
