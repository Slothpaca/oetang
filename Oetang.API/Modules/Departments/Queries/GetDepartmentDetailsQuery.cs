using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Departments.Queries
{
    public class GetDepartmentDetailsQuery : IRequest<Department>
    {
        public long DepartmentId { get; set; }
    }
}
