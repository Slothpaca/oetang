using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oetang.API.Modules.Users.Command;
using Oetang.API.Modules.Users.Queries;

namespace Oetang.API.Modules.Users
{
    // Route hier zorgt ervoor dat het woord "Controller" afgekapt wordt van de class "UsersController".
    // Op die manier wordt het woord "Users" gebruikt om achteraan je api pad te zetten => https://localhost:7245/Users/
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        // Authorize is toegevoegd om enkel 1 rol de toestemming te geven om deze HttpGet call te mogen uitvoeren.
        //[Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        // Authorize is toegevoegd om enkel 1 rol de toestemming te geven om deze HttpGet call te mogen uitvoeren.
        //[Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> GetAllUsers(int id)
        {
            var query = new GetUserDetailsQuery() { UserId = id };
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddNewUserCommand command)
        {
            var newUser = await _mediator.Send(command);
            return Ok(newUser);
        }
    }
}
