using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Customers.Command
{
    public class AddNewCustomerCommand : IRequest<Customer>
    {
        public string? Name { get; set; }
    }
}
