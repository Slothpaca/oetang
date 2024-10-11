using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Users.Queries;

namespace Oetang.API.Modules.Users.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly OetangDbContext dbContext;

        public GetAllUsersQueryHandler(OetangDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query,CancellationToken cancellationToken)
        {
            return await dbContext.User.ToListAsync();
        }
    }

}
