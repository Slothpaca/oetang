// Include necessary namespaces.
using MediatR;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Users.Command;


namespace Oetang.API.Modules.Users.Handlers
{
    // Handler for the AddNewUserCommand, responsible for creating a new user.
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        // Database context for accessing the database.
        private readonly OetangDbContext _dbContext;


        // Constructor for the handler, initializes the database context
        public AddNewUserCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Handles the AddNewUserCommand, creates a new user and saves it to the database.
        public async Task<User> Handle(AddNewUserCommand command, CancellationToken cancellationToken)
        {
            // Validate the command before creating a new user.
            Validate(command);

            // Create a new user based on the command.
            var newUser = new User(command.Name, command.Surname, command.EmailAddress);

            // Add the new user to the database context and save the changes to the database.
            _dbContext.User.Add(newUser);
            await _dbContext.SaveChangesAsync();

            // Return the newly created user.
            return newUser;
        }


        // Validates the AddNewUserCommand, checks for required fields and field lengths.
        private static void Validate(AddNewUserCommand command)
        {
            // Check if the name is not null or empty.
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new Exception("A name is required when creating a new user.");
            }
            // Check if the name exceeds the maximum allowed length
            if (command.Name.Length > 100)
            {
                throw new Exception("The name of a user can not exceed 100 characters.");
            }

            // Check if the surname is not null or empty.
            if (string.IsNullOrWhiteSpace(command.Surname))
                throw new BadHttpRequestException("A surname is required when creating a new user.");

            // Check if the surname exceeds the maximum allowed length
            if (command.Surname.Length > 100)
            {
                throw new Exception("The name of a user can not exceed 100 characters.");
            }

            // Check if the emailaddrss is not null or empty.
            if (string.IsNullOrWhiteSpace(command.EmailAddress))
                throw new BadHttpRequestException("An email address is required when creating a new user.");

            // Check if the emailaddrss exceeds the maximum allowed length
            if (command.EmailAddress.Length > 100)
            {
                throw new Exception("The name of a user can not exceed 100 characters.");
            }
        }
    }
}
