// Include necessary namespaces.
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Users.Queries;


namespace Oetang.API.Modules.Users.Handlers
{
    // Handler for the GetUserDetailsQuery, responsible for retrieving a user by ID.
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, User>
    {
        // Database context for accessing the database.
        private readonly OetangDbContext dbContext;


        // Constructor for the handler, initializes the database context.
        public GetUserDetailsQueryHandler(OetangDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // Handles the GetUserDetailsQuery, retrieves a user by ID from the database.
        public async Task<User> Handle(GetUserDetailsQuery query, CancellationToken cancellationToken)
        {
            // Retrieves one singular user from the database by ID using the SingleOrDefaultAsync method.
            var user = await dbContext.User
                .SingleOrDefaultAsync(user => user.Id == query.UserId);
            
            // Checks if the user is found.
            if (user is not null)
            {
                // Returns the found user.
                return user;
            }
            else
            {
                throw new BadHttpRequestException("Eje were gezopen, tklopt nie nie he da nummerke daje ingaf");
            }
        }
    }
}
