// Include needed namespaces.
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Command;


// (info) Namespaces are used organize code and group related classes, interfaces, and other types together.
namespace Oetang.API.Modules.Customers.Handlers
{
    // Handler for processing the UpdateCustomerCommand.
    // Implements IRequestHandler, which handles the input command (UpdateCustomerCommand) and outputs a Customer object (Customer).
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        
        // OetangDbContext is a custom class that extends DbContext and represents a connection to the database.
            // _dbContext (of the type OetangDbContext) represents the database context. Private => Only accessible from within this class.
        private readonly OetangDbContext _dbContext;


        //private readonly IHttpContextAccessor httpContextAccessor;


        // Constructor that is used to inject the "OetangDbContext" dependency into the class.
        public UpdateCustomerCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Logic to update customer happens here:
        public async Task<Customer> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {

            // Validate inputs - check if the provided command contains valid data.
            Validate(command);


            // Find the customer in the database using the provided customer ID from the command and put it in a variable.
            var customer = await _dbContext.Customers
                .SingleOrDefaultAsync(customer => customer.Id == command.CustomerId);


            // If no customer is found, throw an error message.
            if (customer == null)
            {
                // Handle "not found" case
                throw new BadHttpRequestException("No customer exists with that ID.");
            }


            // Replace the name field of customer with the value provided by command.
            customer.Name = command.NewName;


            // Save changes to the database after updating the customer.
            await _dbContext.SaveChangesAsync();    // Save all modifications to the database.
            return customer;                        // Return the updated department.
        }


        // This method checks if the input command contains valid data.
        private static void Validate(UpdateCustomerCommand command)
        {

            // Check if the NewName is empty or contains only whitespace.
            if (string.IsNullOrWhiteSpace(command.NewName))
            {
                throw new Exception("A name is required when updating a customer.");
            }

            // Check if the NewName is length does not exceed a given limit of characters.
            if (command.NewName.Length > 100)
            {
                throw new Exception("The name of a customer cannot exceed 100 characters.");
            }
        }
    }
}
