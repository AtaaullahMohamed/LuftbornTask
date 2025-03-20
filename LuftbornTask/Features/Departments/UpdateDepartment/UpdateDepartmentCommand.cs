using MediatR;

namespace LuftbornTask.Features.Departments.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
