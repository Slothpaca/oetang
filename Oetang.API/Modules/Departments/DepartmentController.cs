using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oetang.API.Modules.Departments.Command;
using Oetang.API.Modules.Departments.Queries;

namespace Oetang.API.Modules.Departments
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var query = new GetAllDepartmentsQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentDetails(long id)
        {
            var query = new GetDepartmentDetailsQuery() { DepartmentId = id };
            var department = await _mediator.Send(query);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDepartment(AddNewDepartmentCommand command)
        {
            var newDepartment = await _mediator.Send(command);
            return Ok(newDepartment);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDepartment(long id, UpdateDepartmentCommand command)
        {
            // Binnen de swagger http requests hoeft ("DepartmentId": 0) niet aangepast te worden, id uit de request overschrijft die waarde.
            command.DepartmentId = id; // Set the department ID from the URL

            var updatedDepartment = await _mediator.Send(command);
            if (updatedDepartment == null)
            {
                return NotFound();
            }

            return Ok(updatedDepartment);
        }
    }
}
