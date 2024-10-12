// Include necessary namespaces
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Customers.Queries
{
    // GetAllCustomersQuery class implements the IRequest interface from MediatR.
    // It represents a query to retrieve a collection (IEnumerable) of Customer objects.
    // No additional properties are needed for this query since it simply retrieves all customers.
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    { }
}
