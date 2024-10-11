using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Dtos;
using Oetang.API.Modules.Users.Queries;

namespace Oetang.API.Modules.Users.Handlers
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, User>
    {
        private readonly OetangDbContext dbContext;

        public GetUserDetailsQueryHandler(OetangDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> Handle(GetUserDetailsQuery query,
            CancellationToken cancellationToken)
        {
            var user = await dbContext.User
                .SingleOrDefaultAsync(user => user.Id == query.UserId);

            if(user is not null)
            {
                return user;
            }
            else
            {
                throw new BadHttpRequestException("Eje were gezopen, tklopt nie nie he da nummerke daje ingaf");
            }
        }
    }
}
