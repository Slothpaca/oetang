// Include necessary namespaces
using MediatR;
using Oetang.API.Domain;


namespace Oetang.API.Modules.Departments.Queries
{
    // Query class to retrieve all departments. 
    // Implements IRequest from MediatR, which expects a response of a collection of Department entities.
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<Department>>
    {
        // The class is empty because it only serves as a marker for the request.
        // MediatR will use this class to trigger the handler that processes the query.
    }
}
