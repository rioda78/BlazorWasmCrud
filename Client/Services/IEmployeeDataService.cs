using BlazorWasmCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
