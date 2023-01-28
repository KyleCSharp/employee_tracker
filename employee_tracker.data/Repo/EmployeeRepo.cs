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

        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            var rowsAffected = await conn.QueryFirstOrDefaultAsync<int>(
                "INSERT INTO employee (NAME, EMAIL, PAY_RATE, STATE, Address_1, Address_2, phone, Zip_Code, City, Hired_at ) VALUES (@NAME, @EMAIL, @PAY_RATE, @STATE, @Address_1, @Address_2, @phone, @Zip_Code, @City, @Hired_at); SELECT SCOPE_IDENTITY();",
                new { employee.Name, employee.Email, employee.Pay_Rate, employee.State, employee.Address_1, employee.Address_2, employee.phone, employee.Zip_Code, employee.City, employee.Hired_at });
            return rowsAffected;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            using var conn = new SqlConnection(_config.GetConnectionString());
            conn.Open();
            int rowsAffected = await conn.ExecuteAsync("DELETE FROM employee WHERE ID = @id;", new { id });
            return rowsAffected;
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
            await conn.ExecuteAsync(@"UPDATE employee SET Name = @Name, address_1 = @address_1, address_2 = @address_2, city = @city, state = @state, Zip_Code = @Zip_Code, 
                phone = @phone, Email = @Email, Pay_Rate = @Pay_Rate WHERE ID = @ID"
            , new { name = employee.Name, employee.Address_1, employee.Address_2, employee.City, employee.State, employee.Zip_Code, employee.phone
              , employee.Email, employee.Pay_Rate, employee.ID });
            return await GetEmployeeByIdAsync(employee.ID);
        }
    }
}
