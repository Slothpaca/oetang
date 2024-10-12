// Include needed namespaces.
using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Customers.Command
{
    // This class specifies: it (the class) represents a request that, when handled, will return an object of type Customer.
    // See at the bottom for deeper explanation of IRequest.
    public class AddNewCustomerCommand : IRequest<Customer>
    {
        // Property
        public required string Name { get; set; }
    }
}



// Explanations:

// IRequest<>: (generic interface provided by MediatR here)
    // An interface defines a contract that classes can implement.
    // It specifies methods or properties that a class must have.
    // By implementing IRequest<T>, the class is promising to provide the functionality described by the interface.