using LuftbornTask.Data;
using LuftbornTask.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LuftbornTask.Features.Departments.GetDepartmnts
{
    public class GetDeparmentsHandler : IRequestHandler<GetDepartmntesQuery, List<Department>>
    {
        private readonly AppDbContext context;
        public GetDeparmentsHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Department>> Handle(GetDepartmntesQuery request, CancellationToken cancellationToken)
        {
            return await context.Departments.ToListAsync(cancellationToken);

        }
    }
}
