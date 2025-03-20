using LuftbornTask.Data;
using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.UpdateDepartment
{
    public class UpdateDepartmentHandler :IRequestHandler <UpdateDepartmentCommand>
    {
        private readonly AppDbContext  context;

        public UpdateDepartmentHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = await context.Departments.FindAsync(request.Id);

            department.Name = request.Name;
            department.Description = request.Description;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
