// Include necessary namespaces
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Oetang.API.Modules.Customers.Command;
using Oetang.API.Modules.Customers.Queries;


namespace Oetang.API.Modules.Customers
{
    // Define an API controller for customer-related actions.
    // The controller is mapped to the route "/customers" due to the attribute [Route].
    // Route will cut off the part between brackets -> [] from the class names (here CustomerController -> Customers. 
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // The _mediator object is used to send commands or queries via MediatR.
        private readonly IMediator _mediator;


        // Constructor for CustomersController. It injects the IMediator instance into the controller.
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET /customers - Retrieves a list of all customers.
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            // Create an instance of GetAllCustomersQuery to send through MediatR.
            var query = new GetAllCustomersQuery();

            // Send the query to MediatR and retrieve the list of customers.
            var customers = await _mediator.Send(query);

            // Return the list of customers in an HTTP 200 OK response.
            return Ok(customers);
        }


        // GET /customers/{id} - Retrieves details of a specific customer by ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetails(long id)
        {
            // Create an instance of GetCustomerDetailsQuery with the provided customer ID.
            var query = new GetCustomerDetailsQuery() { CustomerId = id };

            // Send the query to MediatR and retrieve the customer details.
            var customer = await _mediator.Send(query);

            // Return the customer details in an HTTP 200 OK response.
            return Ok(customer);
        }


        // POST /customers - Adds a new customer to the system.
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(AddNewCustomerCommand command)
        {
            // Send the AddNewCustomerCommand to MediatR to add a new customer.
            var newCustomer = await _mediator.Send(command);

            // Return the newly created customer in an HTTP 200 OK response.
            return Ok(newCustomer);
        }


        // PATCH /customers/{id} - Updates an existing customer's information.
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, UpdateCustomerCommand command)
        {
            // Assign the customer ID from the URL path to the command's CustomerId property.
            // In Swagger HTTP requests, the "CustomerId": 0 in the body is overwritten by this ID.
            command.CustomerId = id;

            // Send the UpdateCustomerCommand to MediatR to update the customer.
            var updatedCustomer = await _mediator.Send(command);

            // If no customer is found, return an HTTP 404 Not Found response.
            if (updatedCustomer == null)
            {
                return NotFound();
            }

            // Return the updated customer in an HTTP 200 OK response.
            return Ok(updatedCustomer);
        }
    }
}
