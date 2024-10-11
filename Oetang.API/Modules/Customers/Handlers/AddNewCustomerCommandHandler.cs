using MediatR;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Command;

namespace Oetang.API.Modules.Customers.Handlers
{
    public class AddNewCustomerCommandHandler : IRequestHandler<AddNewCustomerCommand, Customer>
    {
        private readonly OetangDbContext _dbContext;

        public AddNewCustomerCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(AddNewCustomerCommand command, CancellationToken cancellationToken)
        {
            Validate(command);

            var newCustomer = new Customer(command.Name);

            _dbContext.Customers.Add(newCustomer);
            await _dbContext.SaveChangesAsync();

            return newCustomer;
        }

        private static void Validate(AddNewCustomerCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new Exception("A name is required when creating a new customer.");
            }

            if (command.Name.Length > 100)
            {
                throw new Exception("The name of a customer can not exceed 100 characters.");
            }
        }
    }
}
