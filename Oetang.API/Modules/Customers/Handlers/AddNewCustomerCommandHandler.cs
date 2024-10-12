// Include needed namespaces.
using MediatR;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Command;


namespace Oetang.API.Modules.Customers.Handlers
{
    // Handler for processing the AddNewCustomerCommand.
    // Implements IRequestHandler, which handles the input command (AddNewCustomerCommand) and outputs a Customer object (Customer).
    public class AddNewCustomerCommandHandler : IRequestHandler<AddNewCustomerCommand, Customer>
    {
        // Dependency injection of the database context to access the database.
        private readonly OetangDbContext _dbContext;


        // Constructor to initialize the database context.
        public AddNewCustomerCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Handle method processes the AddNewCustomerCommand and returns a new Customer.
        public async Task<Customer> Handle(AddNewCustomerCommand command, CancellationToken cancellationToken)
        {
            // Validate the command input.
            Validate(command);

            // Create a new Customer object using the name provided in the command.
            var newCustomer = new Customer(command.Name);

            // Add the new customer to the Customers DbSet (table) in the database and save changes asynchronously.
            _dbContext.Customers.Add(newCustomer);
            await _dbContext.SaveChangesAsync();

            // Return the newly created Customer object.
            return newCustomer;
        }


        // Validate method ensures that the input command is valid.
        private static void Validate(AddNewCustomerCommand command)
        {
            // Check if the customer name is not empty or just whitespace.
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new Exception("A name is required when creating a new customer.");
            }

            // Check if the customer name exceeds 100 characters.
            if (command.Name.Length > 100)
            {
                throw new Exception("The name of a customer can not exceed 100 characters.");
            }
        }
    }
}
