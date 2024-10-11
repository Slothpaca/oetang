using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Queries;

namespace Oetang.API.Modules.Customers.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
    {
        private readonly OetangDbContext dbContext;

        public GetAllCustomersQueryHandler(OetangDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            return await dbContext.Customers.ToListAsync();
        }
    }
}
