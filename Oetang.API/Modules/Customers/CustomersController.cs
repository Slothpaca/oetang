using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Oetang.API.Database;
using Oetang.API.Domain;
using Oetang.API.Modules.Customers.Command;
using Oetang.API.Modules.Customers.Queries;

namespace Oetang.API.Modules.Customers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetails(long id)
        {
            var query = new GetCustomerDetailsQuery() { CustomerId = id };
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(AddNewCustomerCommand command)
        {
            var newCustomer = await _mediator.Send(command);
            return Ok(newCustomer);
        }
    }
}
