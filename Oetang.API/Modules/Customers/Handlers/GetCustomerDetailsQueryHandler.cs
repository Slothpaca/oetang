using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Dtos;
using Oetang.API.Modules.Customers.Queries;

namespace Oetang.API.Modules.Customers.Handlers
{
    public class GetCustomerDetailsQueryHandler
        : IRequestHandler<GetCustomerDetailsQuery, CustomerDto>
    {
        private readonly OetangDbContext dbContext;

        public GetCustomerDetailsQueryHandler(OetangDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CustomerDto> Handle(GetCustomerDetailsQuery query,
            CancellationToken cancellationToken)
        {
            var customer = await dbContext.Customers
                .SingleOrDefaultAsync(customer => customer.Id == query.CustomerId);

            return CustomerDto.MapFromCustomer(customer);
        }
    }
}
