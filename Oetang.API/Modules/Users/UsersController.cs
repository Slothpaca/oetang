// Include necessary namespaces.
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oetang.API.Modules.Users.Command;
using Oetang.API.Modules.Users.Queries;


namespace Oetang.API.Modules.Users
{
    // This attribute removes the "Controller" suffix from the class name, 
    // so the route will be based on the class name without "Controller" => https://localhost:7245/Users/.
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // Mediator instance for handling commands and queries.
        private readonly IMediator _mediator;


        // Constructor for the controller, initializes the mediator.
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET /Users
        [HttpGet]
        // This method retrieves all users
        // Authorize attribute (line underneath) is commented out, but it can be used to restrict access.
        //[Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> GetAllUsers()
        {
            // Creates a new instance of the GetAllUsersQuery.
            var query = new GetAllUsersQuery();

            // Sends the query to the mediator to handle it.
            var users = await _mediator.Send(query);

            // Returns the result as an OK response.
            return Ok(users);
        }


        // GET /Users/{id}
        [HttpGet("{id}")]
        // This method retrieves a user by ID
        // Authorize attribute (line underneath) is commented out, but it can be used to restrict access.
        //[Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> GetAllUsers(int id)
        {
            // Creates a new instance of the GetUserDetailsQuery with the provided ID.
            var query = new GetUserDetailsQuery() { UserId = id };

            // Sends the query to the mediator to handle it.
            var user = await _mediator.Send(query);

            // Returns the result as an OK response.
            return Ok(user);
        }


        // POST /Users
        [HttpPost]
        // This method adds a new user.
        public async Task<IActionResult> AddNewUser(AddNewUserCommand command)
        {
            // Sends the command to the mediator to handle it.
            var newUser = await _mediator.Send(command);

            // Returns the result as an OK response.
            return Ok(newUser);
        }
    }
}
