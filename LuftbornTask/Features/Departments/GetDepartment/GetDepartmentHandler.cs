using LuftbornTask.Data;
using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.GetDepartment
{
    public class GetDepartmentHandler : IRequestHandler<GetDepartmentQuery, Department>
    {
        private readonly AppDbContext context;

        public GetDepartmentHandler(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<Department> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await context.Departments.FindAsync(request.Id, cancellationToken);

        }
    }
}
