// Include needed namespaces.
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Departments.Command;


// (info) Namespaces are used organize code and group related classes, interfaces, and other types together.
namespace Oetang.API.Modules.Departments.Handlers
{

    // (info) Class is a blueprint for creating the object => Here it is "UpdateDepartmentCommandHandler".
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Department>
    {

        // OetangDbContext is a custom class that extends DbContext and represents a connection to the database.
            // _dbContext (of the type OetangDbContext) represents the database context. Private => Only accessible from within this class.
        private readonly OetangDbContext _dbContext;


        // Constructor that is used to inject the "OetangDbContext" dependency into the class.
        public UpdateDepartmentCommandHandler(OetangDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Logic to update department happens here:
        public async Task<Department> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            // Validate inputs - check if the provided command contains valid data.
            Validate(command);


            // Find the department in the database using the provided department ID from the command and put it in a variable.
                // -> The Include() method also loads the Manager information related to the department.
            var department = await _dbContext.Departments
                .Include(department => department.Manager)
                .SingleOrDefaultAsync(department => department.Id == command.DepartmentId); // Is there a department in the database that has the same ID as the one provided


            // If no department is found, throw an error message.
            if (department == null)
            {
                throw new Exception("Department not found.");
            }


            // If a new department name is provided in the command, update the department’s name.
            if (command.NewName != null)
            {
                // Replace the name field of department with the value provided by command.
                department.Name = command.NewName;
            }


            // If a new department manager (head) ID is provided, update the department manager
            if (command.NewDepartmentHeadId.HasValue)
            {
                // Find the user who will be the new department manager using the provided ID.
                var newManager = await _dbContext.User
                    .SingleOrDefaultAsync(user => user.Id == command.NewDepartmentHeadId.Value, cancellationToken: cancellationToken)   // Check if the user exists.
                        ?? throw new KeyNotFoundException("The specified user does not exist.");                                        // Throw error if no user is found.


                // Assign the DepartmentHead role to the new manager.
                newManager.MakeDepartmentHead();


                // Check if the old manager is still managing other departments.
                var allDepartmentsOldManager = await _dbContext.Departments
                    .Include(d => d.Manager)                        // Load the manager information for each department.
                    .Where(d => d.Manager == department.Manager)    // Find all departments managed by the current manager.
                    .ToListAsync();


                // If the old manager is not managing any other departments, remove the "DepartmentHead" role.
                if (allDepartmentsOldManager.Count == 1)
                {
                    department.Manager.RemoveDepartmentHeadRole();  // If the manager is only managing this department, remove their manager role.
                }


                // Set the new manager as the current department’s manager.
                department.Manager = newManager;
            }


            // Save changes to the database after updating the department.
            await _dbContext.SaveChangesAsync();    // Save all modifications to the database.
            return department;                      // Return the updated department.
        }


        // This method checks if the input command contains valid data.
        private void Validate(UpdateDepartmentCommand command)
        {

            // Check if a new name has been provided in the command. If the "NewName" field is not null, check if it is empty or contains only whitespace.
            if (command.NewName != null && string.IsNullOrWhiteSpace(command.NewName))
            {

                // If the new name is empty or just spaces, throw an exception with a message. This ensures that the department has a valid, non-empty name when updating.
                throw new Exception("A name is required when updating a department.");
            }
        }
    }
}
