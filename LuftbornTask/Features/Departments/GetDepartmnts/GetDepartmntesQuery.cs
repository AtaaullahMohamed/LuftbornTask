using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.GetDepartmnts
{
    public class GetDepartmntesQuery : IRequest<List<Department>>
    { 
    }
}
