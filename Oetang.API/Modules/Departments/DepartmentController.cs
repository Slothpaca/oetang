// Include necessary namespaces
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oetang.API.Modules.Departments.Command;
using Oetang.API.Modules.Departments.Queries;


namespace Oetang.API.Modules.Departments
{
    // Define an API controller for department-related actions.
    // The controller is mapped to the route "/department" due to the attribute [Route].
    // Route will cut off the part between brackets -> [] from the class names (here departmentController -> Department. 
    [Route("[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // The mediator object is used to send commands and queries.
        private readonly IMediator _mediator;


        // Constructor that injects the mediator.
        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET /departments - Retrieves a list of all departments.
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            // Create an instance of GetAllDepartmentsQuery to send through MediatR.
            var query = new GetAllDepartmentsQuery();

            // Sends the query to the mediator and retreive a list of departments.
            var departments = await _mediator.Send(query);

            // Returns the result as an OK (HTTP 200) response.
            return Ok(departments);
        }


        // GET /departments/{id} - Retrieves details of a specific department by ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentDetails(long id)
        {
            // Create an instance of GetDepartmentDetailsQuery with the provided department ID.
            var query = new GetDepartmentDetailsQuery() { DepartmentId = id };

            // Send the query to MediatR and retrieve the department details.
            var department = await _mediator.Send(query);

            // Return the department details in an HTTP 200 OK response.
            return Ok(department);
        }


        // POST /departments - Adds a new department to the system.
        [HttpPost]
        public async Task<IActionResult> AddNewDepartment(AddNewDepartmentCommand command)
        {
            // Send the AddNewDepartmentCommand to MediatR to add a new department.
            var newDepartment = await _mediator.Send(command);

            // Return the newly created department in an HTTP 200 OK response.
            return Ok(newDepartment);
        }


        // PATCH /departments/{id} - Updates an existing department's information.
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDepartment(long id, UpdateDepartmentCommand command)
        {
            // Assign the department ID from the URL path to the command's DepartmentId property.
            // In Swagger HTTP requests, the "DepartmentId": 0 in the body is overwritten by this ID.
            command.DepartmentId = id;

            // Send the UpdateDepartmentCommand to MediatR to update the department.
            var updatedDepartment = await _mediator.Send(command);

            // If no department is found, return an HTTP 404 Not Found response.
            if (updatedDepartment == null)
            {
                return NotFound();
            }

            // Return the updated department in an HTTP 200 OK response.
            return Ok(updatedDepartment);
        }
    }
}
