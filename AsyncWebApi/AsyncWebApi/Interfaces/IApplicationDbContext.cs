using AsyncWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncWebApi.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<EmployeeEntity>? Employees { get; set; }
        Task<int> SaveChanges();
    }
}
