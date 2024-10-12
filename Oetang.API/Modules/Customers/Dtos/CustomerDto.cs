// Include necessary namespaces.
using Oetang.API.Domain;


namespace Oetang.API.Modules.Customers.Dtos
{
    // This class represents DTO for a customer.
    public class CustomerDto
    {
        // Properties
        public long Id { get; set; }
        public string Name { get; set; }


        // Static method to map a Customer object to a CustomerDto.
        // This is useful when we want to return customer data in a more controlled or simplified form, without exposing all the details of the Customer class.
        public static CustomerDto MapFromCustomer(Customer customer)
        {
            // Creates and returns a new CustomerDto instance based on the provided Customer object.
            // AKA new CustomerDto instance only with properties we don't mind exposing.
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }
    }
}




// Explanations:

// DTO = Data Transfer Object
    // DTOs are used to transfer data between different parts of the application.
    // e.g., between the server and the client.