using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Customers.Command
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public long CustomerId { get; set; }
        public string NewName { get; set; }
    }
}
