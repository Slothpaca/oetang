using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimesheetApp.API.Users.Queries;

namespace TimesheetApp.API.Users;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetUser(id);
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}