using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Department>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
