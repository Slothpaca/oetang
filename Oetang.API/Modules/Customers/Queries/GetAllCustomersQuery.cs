using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    { }
}
