using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Departments.Queries
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<Department>>
    {
    }
}
