using AsyncWebApi.Models;
using System.Threading.Tasks;

namespace AsyncWebApi.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Task<List<Employee>> GetEmployeesAsync();
        Task<EmployeeEntity> PostEmployee(EmployeeEntity employee);
        Task<EmployeeEntity> UpdateEmployee(EmployeeEntity employee);
    }
}
