using employee_tracker.domain.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing.Text;

namespace employee_tracker.Config
{
    public class EmployeeTrackerConfig : IConfig
    {
        public string GetConnectionString()
        {
           var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config [_configKey] ?? throw new ApplicationException("No config found for database connection");// if appsetting is not found throw ex
        }
        private const string _configKey = "ConnectionStrings:DefaultConnection";
    }
}
