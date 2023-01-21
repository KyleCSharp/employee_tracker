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
            return await conn.QueryFirstOrDefaultAsync<Employee>("SELECT * FROM dbo.employee " +
                "WHERE name = @name", new { name = name });
        }
    }
}
