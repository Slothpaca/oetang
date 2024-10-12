// Include necessary namespaces
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Queries;


namespace Oetang.API.Modules.Customers.Handlers
{
    // Handler for processing the GetAllCustomersQuery.
    // Implements IRequestHandler, which handles the input command (GetAllCustomersQuery) and outputs list of customers (Customer).
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        // Dependency injection of the database context to access the database.
        private readonly OetangDbContext _dbContext;

        // Constructor to initialize the database context.
        public GetAllCustomersQueryHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Handle method processes the GetAllCustomersQuery and returns a list of customers.
        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            // Asynchronously retrieves all customers from the database and returns them as a list.
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
