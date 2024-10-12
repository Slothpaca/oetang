// Include necessary namespaces.
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Users.Queries;


namespace Oetang.API.Modules.Users.Handlers
{
    // Handler for the GetAllUsersQuery, responsible for retrieving all users.
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        // Database context for accessing the database.
        private readonly OetangDbContext _dbContext;


        // Constructor for the handler, initializes the database context.
        public GetAllUsersQueryHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Handles the GetAllUsersQuery, retrieves all users from the database.
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query,CancellationToken cancellationToken)
        {
            // Retrieves all users from the database using the ToListAsync method.
            return await _dbContext.User.ToListAsync();
        }
    }

}
