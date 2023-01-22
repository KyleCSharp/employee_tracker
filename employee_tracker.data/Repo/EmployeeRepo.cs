using employee_tracker.domain.Interfaces;
using employee_tracker.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Runtime.InteropServices;

namespace employee_tracker.data.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
         private readonly IConfig _config;

        public EmployeeRepo(IConfig config)
        {
            _config = config;
        }

        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            return await conn.QueryAsync<Employee>("SELECT * FROM dbo.employee");
        }

        public  async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            return await conn.QueryFirstOrDefaultAsync<Employee>("SELECT * FROM dbo.employee " +
                "WHERE id = @id", new {id = id });
        }

        public async Task<Employee> GetEmployeeByNameAsync(string name)
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            var sql = "SELECT * FROM dbo.employee WHERE name LIKE '%'  + @name + '%'";
            var param = new {name = name};
            return await conn.QueryFirstOrDefaultAsync<Employee>(sql,param);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
           using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            await conn.ExecuteAsync(@"UPDATE employee SET Name = @Name WHERE ID = @ID"
            , new { name = employee.Name, employee.Address_1, employee.Address_2, employee.City, employee.State, employee.Zip_Code, employee.phone
              , employee.Email, employee.Pay_Rate, employee.ID });
            return await GetEmployeeByIdAsync(employee.ID);
        }
    }
}
