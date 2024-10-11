using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, UpdateCustomerCommand command)
        {
            // Binnen de swagger http requests hoeft ("CustomerId": 0) niet aangepast te worden, id uit de request overschrijft die waarde.
            command.CustomerId = id;

            var updatedCustomer = await _mediator.Send(command);
            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return Ok(updatedCustomer);
        }
    }
}
