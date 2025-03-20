using MediatR;

namespace LuftbornTask.Features.Departments.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest 
    {
        public int Id { get; set; }

        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
