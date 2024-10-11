using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Departments.Command
{
    public class AddNewDepartmentCommand : IRequest<Department>
    {
        public string Name { get; set; }
        public long DepartmentHeadId { get; set; }
    }
}
