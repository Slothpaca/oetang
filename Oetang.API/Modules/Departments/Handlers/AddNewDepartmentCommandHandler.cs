// Include the namespace
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Departments.Command;


namespace Oetang.API.Modules.Departments.Handlers
{
    // Handler for processing the AddNewDepartmentCommand.
    // Implements IRequestHandler, which handles the input command (AddNewDepartmentCommand) and outputs a Customer object (Department).
    public class AddNewDepartmentCommandHandler : IRequestHandler<AddNewDepartmentCommand, Department>
    {
        // Database context to interact with the database.
        private readonly OetangDbContext _dbContext;


        // Constructor to inject the database context dependency.
        public AddNewDepartmentCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        // Handles the command to add a new department.
        public async Task<Department> Handle(AddNewDepartmentCommand command, CancellationToken cancellationToken)
        {
            // Validate the command input.
            Validate(command);

            // Find the user who will be the department head based on the ID provided in the command.
            var manager = await _dbContext.User
                .SingleOrDefaultAsync(user => user.Id == command.DepartmentHeadId, cancellationToken);

            // Create a new department with the name and manager that are provided.
            var newDepartment = new Department(command.Name, manager);

            // Add the new department to the database and save the changes.
            _dbContext.Departments.Add(newDepartment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Return the newly created department.
            return newDepartment;
        }


        // Validates the input data in the command to ensure correctness.
        private void Validate(AddNewDepartmentCommand command)
        {
            // Ensure the department name is not empty or just whitespace.
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new Exception("A name is required when creating a new department.");
            }

            // Ensure the department name does not exceed 50 characters.
            if (command.Name.Length > 50)
            {
                throw new Exception("The name of a department can not exceed 50 characters.");
            }

            // Ensure the department head ID is valid (not zero).
            if (command.DepartmentHeadId == 0)
            {
                throw new Exception("User ID can not be 0");
            }
        }
    }
}
