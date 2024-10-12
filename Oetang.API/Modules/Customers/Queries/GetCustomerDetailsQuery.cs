// Include necessary namespaces
using MediatR;
using Oetang.API.Modules.Customers.Dtos;


namespace Oetang.API.Modules.Customers.Queries
{
    // GetCustomerDetailsQuery class implements the IRequest interface from MediatR.
    // This class represents a query to retrieve detailed information of a specific customer.
    // The expected return type is CustomerDto, which is a Data Transfer Object.
    public class GetCustomerDetailsQuery : IRequest<CustomerDto>
    {
        // Property to hold the ID of the customer whose details are being requested.
        // This ID will be provided when the query is executed.
        public long CustomerId { get; set; }
    }
}
