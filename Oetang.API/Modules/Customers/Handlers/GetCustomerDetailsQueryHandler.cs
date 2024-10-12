// Include necessary namespaces
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Modules.Customers.Dtos;
using Oetang.API.Modules.Customers.Queries;


namespace Oetang.API.Modules.Customers.Handlers
{
    // Handler for processing the GetCustomerDetailsQuery.
    // It implements IRequestHandler, which handles the input query and returns a CustomerDto.
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDto>
    {
        // Dependency injection of the database context to access the database.
        private readonly OetangDbContext _dbContext;

        // Constructor to initialize the database context.
        public GetCustomerDetailsQueryHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Handle method processes the GetCustomerDetailsQuery and returns customer details as a CustomerDto.
        public async Task<CustomerDto> Handle(GetCustomerDetailsQuery query, CancellationToken cancellationToken)
        {
            // Asynchronously finds a customer by its ID from the database.
            var customer = await _dbContext.Customers.SingleOrDefaultAsync(customer => customer.Id == query.CustomerId);

            // Maps the customer entity to a CustomerDto and returns it.
            return CustomerDto.MapFromCustomer(customer);
        }
    }
}
