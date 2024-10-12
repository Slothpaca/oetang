// Include the namespace
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Departments.Command
{
    // This class specifies: it (the class) represents a request that, when handled, will return an object of type Department.
    // See at the bottom for deeper explanation of IRequest.
    public class UpdateDepartmentCommand : IRequest<Department>
    {
        // Properties
        public long DepartmentId { get; set; } // ID of the department that needs updating
        public string? NewName { get; set; } // The new name for the department
        public long? NewDepartmentHeadId { get; set; } // The ID of the new manager
    }
}




// Explanations:

// IRequest<>: (generic interface provided by MediatR here)
// An interface defines a contract that classes can implement.
// It specifies methods or properties that a class must have.
// By implementing IRequest<T>, the class is promising to provide the functionality described by the interface.