// Include the namespace
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Users.Command
{
    // This class specifies: it (the class) represents a request that, when handled, will return an object of type User.
    // See at the bottom for deeper explanation of IRequest.
    public class AddNewUserCommand : IRequest<User>
    {
        // Property
        public string? Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
    }
}




// Explanations:

// IRequest<>: (generic interface provided by MediatR here)
// An interface defines a contract that classes can implement.
// It specifies methods or properties that a class must have.
// By implementing IRequest<T>, the class is promising to provide the functionality described by the interface.