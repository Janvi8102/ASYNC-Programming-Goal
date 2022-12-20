using AsyncWebApi.Interfaces;
using AsyncWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsyncWebApi.Services
{
    public class EmployeeService :IEmployeeService
    {
        readonly IApplicationDbContext _applicationDbContext;

        public EmployeeService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Employee> GetEmployees()
        {
            return AdaptEmployee(_applicationDbContext.Employees.ToList<EmployeeEntity>());
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return AdaptEmployee(await _applicationDbContext.Employees.ToListAsync<EmployeeEntity>());
        }

        private static List<Employee> AdaptEmployee(List<EmployeeEntity> employeeEntityList)
        {
            List<Employee> employeeList = new();

            Employee? employee;

            foreach (EmployeeEntity employeeEntity in employeeEntityList)
            {
                employee = new()
                {
                    FirstName = employeeEntity.FirstName,
                    MiddleName = employeeEntity.MiddleName,
                    LastName = employeeEntity.LastName,
                    Designation = employeeEntity.Designation
                };
                employeeList.Add(employee);
            }
            return employeeList;
        }

        public async Task<EmployeeEntity> PostEmployee(EmployeeEntity employee)
        {
            var result = await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChanges();
            return employee;
        }

        public async Task<EmployeeEntity> UpdateEmployee(EmployeeEntity employee)
        {

            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChanges();
            return employee;
        }
    }

}
