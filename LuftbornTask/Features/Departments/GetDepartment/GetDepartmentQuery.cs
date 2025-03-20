using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.GetDepartment
{
    public class GetDepartmentQuery : IRequest <Department>
    {
        public int Id { get; set; }

        public GetDepartmentQuery(int id)
        {
            Id = id;
        }
    }
}
