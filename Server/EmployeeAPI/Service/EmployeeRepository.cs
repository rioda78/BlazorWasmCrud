using System.Collections.Generic;
using System.Linq;
using EmployeeAPI.Data;
using EmployeeAPI.Models;

namespace EmployeeAPI.Service
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees.ToList();
        }
        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
        }
        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (foundEmployee != null)
            {
                foundEmployee.City = employee.City;
                foundEmployee.Email = employee.Email;
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.Street = employee.Street;
                foundEmployee.Zip = employee.Zip;
                foundEmployee.Comment = employee.Comment; ;
                _appDbContext.SaveChanges();
                return foundEmployee;
            }
            return null;
        }
        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;
            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }

    }

}