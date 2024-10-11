using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Departments.Command;

namespace Oetang.API.Modules.Departments.Handlers
{
    public class AddNewDepartmentCommandHandler : IRequestHandler<AddNewDepartmentCommand, Department>
    {
        private readonly OetangDbContext _dbContext;

        public AddNewDepartmentCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> Handle(AddNewDepartmentCommand command, CancellationToken cancellationToken)
        {
            Validate(command);

            // Check if the ID provided by the request is in the database
            var manager = await _dbContext.User
                .SingleOrDefaultAsync(user => user.Id == command.DepartmentHeadId, cancellationToken);

            // Create the new department
            var newDepartment = new Department(command.Name, manager);

            // Add the new department to the database
            _dbContext.Departments.Add(newDepartment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newDepartment;
        }

        private void Validate(AddNewDepartmentCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new Exception("A name is required when creating a new department.");
            }

            if (command.Name.Length > 50)
            {
                throw new Exception("The name of a department can not exceed 50 characters.");
            }
            if (command.DepartmentHeadId == 0)
            {
                throw new Exception("User ID can not be 0");
            }
        }
    }
}
