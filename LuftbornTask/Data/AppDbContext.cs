using LuftbornTask.Models;
using Microsoft.EntityFrameworkCore;

namespace LuftbornTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {
            
        }

       public DbSet <Department> Departments {  get; set; }  
    }
}
