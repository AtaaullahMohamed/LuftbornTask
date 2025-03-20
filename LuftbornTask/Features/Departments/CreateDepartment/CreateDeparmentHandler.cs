using LuftbornTask.Data;
using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.CreateDepartment
{
    public class CreateDeparmentHandler : IRequestHandler<CreateDepartmentCommand, Department>
    {
        private readonly AppDbContext context;

        public CreateDeparmentHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = new Department()
            {
                Name = request.Name,
                Description = request.Description
            };
            context.Departments.Add(department);
            await context.SaveChangesAsync();
            return department;

        }
    }
}
