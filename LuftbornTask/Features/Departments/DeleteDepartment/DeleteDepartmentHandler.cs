using LuftbornTask.Data;
using LuftbornTask.Models;
using MediatR;

namespace LuftbornTask.Features.Departments.DeleteDepartment
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly AppDbContext context;

        public DeleteDepartmentHandler(AppDbContext context)
        {
            this.context = context;
        }


        public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = await context.Departments.FindAsync(request.Id);

            context.Departments.Remove(department);
            await context.SaveChangesAsync(cancellationToken);
        }

    }
}
