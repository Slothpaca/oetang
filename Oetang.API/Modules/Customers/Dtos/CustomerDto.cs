using Oetang.API.Domain;

namespace Oetang.API.Modules.Customers.Dtos
{
    public class CustomerDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public static CustomerDto MapFromCustomer(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }
    }
}
