using MediatR;
using Oetang.API.Modules.Customers.Dtos;

namespace Oetang.API.Modules.Customers.Queries
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDto>
    {
        public long CustomerId { get; set; }
    }
}
