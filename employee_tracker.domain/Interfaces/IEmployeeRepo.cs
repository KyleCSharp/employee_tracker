using employee_tracker.domain.Interfaces;
using employee_tracker.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace employee_tracker.domain.Interfaces
{
    public interface IEmployeeRepo
    {
        public Task<Employee> GetEmployeeByNameAsync (string name);
        public Task<Employee> GetEmployeeByIdAsync (int id);
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        public Task<Employee> UpdateEmployeeAsync(Employee employee);
        public Task<int> AddEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int id);
        

        


    }
}

