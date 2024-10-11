using MediatR;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Users.Command;

namespace Oetang.API.Modules.Users.Handlers
{
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly OetangDbContext dbContext;

        public AddNewUserCommandHandler(OetangDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> Handle(AddNewUserCommand command, CancellationToken cancellationToken)
        {
            Validate(command);

            var newUser = new User(command.Name, command.Surname, command.EmailAddress);

            dbContext.User.Add(newUser);
            await dbContext.SaveChangesAsync();

            return newUser;
        }

        private static void Validate(AddNewUserCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new Exception("A name is required when creating a new user.");
            }

            if (command.Name.Length > 100)
            {
                throw new Exception("The name of a user can not exceed 100 characters.");
            }
        }
    }
}
