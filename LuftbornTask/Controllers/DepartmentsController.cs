using LuftbornTask.Features.Departments.CreateDepartment;
using LuftbornTask.Features.Departments.DeleteDepartment;
using LuftbornTask.Features.Departments.GetDepartment;
using LuftbornTask.Features.Departments.GetDepartmnts;
using LuftbornTask.Features.Departments.UpdateDepartment;
using LuftbornTask.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuftbornTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ISender sender;

        public DepartmentsController(ISender sender)
        {
            this.sender = sender;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="command">The command containing department details.</param>
        /// <returns>Returns the created department.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateDepartment(CreateDepartmentCommand command)
        {
            Department department = await sender.Send(command);
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        /// <summary>
        /// Retrieves all departments.
        /// </summary>
        /// <returns>Returns a list of departments.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return await sender.Send(new GetDepartmntesQuery());
        }

        /// <summary>
        /// Retrieves a specific department by ID.
        /// </summary>
        /// <param name="id">The department ID.</param>
        /// <returns>Returns the department if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartment(int id)
        {
            Department department = await sender.Send(new GetDepartmentQuery(id));
            if (department == null) return NotFound();

            return Ok(department);
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="id">The department ID.</param>
        /// <param name="command">The update command containing new details.</param>
        /// <returns>Returns NoContent if successful, otherwise BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, UpdateDepartmentCommand command)
        {
            if (id != command.Id) return BadRequest();

            await sender.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes a department by ID.
        /// </summary>
        /// <param name="id">The department ID.</param>
        /// <returns>Returns NoContent if deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await sender.Send(new DeleteDepartmentCommand(id));
            return NoContent();
        }
    }
}
