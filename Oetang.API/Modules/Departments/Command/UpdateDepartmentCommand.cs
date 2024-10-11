using MediatR;
using Oetang.API.Domain;

namespace Oetang.API.Modules.Departments.Command
{
    public class UpdateDepartmentCommand : IRequest<Department>
    {
        public long DepartmentId { get; set; } // ID of the department that needs updating
        public string? NewName { get; set; } // The new name for the department
        public long? NewDepartmentHeadId { get; set; } // The ID of the new manager
    }
}
