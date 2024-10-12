// Include necessary namespaces
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Departments.Queries
{
    // Query class to retrieve the details of a specific department. 
    // Implements IRequest from MediatR, which expects a Department entity as the response.
    public class GetDepartmentDetailsQuery : IRequest<Department>
    {
        // Property
        public long DepartmentId { get; set; }
    }
}
