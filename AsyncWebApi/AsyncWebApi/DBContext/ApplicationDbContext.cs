using AsyncWebApi.Interfaces;
using AsyncWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncWebApi.DBContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public DbSet<EmployeeEntity>? Employees { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
