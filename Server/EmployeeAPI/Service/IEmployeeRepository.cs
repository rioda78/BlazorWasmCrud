using System.Collections.Generic;
using EmployeeAPI.Models;

namespace EmployeeAPI.Service
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee GetEmployeeById(int employeeId);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
