using employee_tracker.data.Repo;
using employee_tracker.domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace employee_tracker.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public IActionResult Index() 
        {
            return View();
        }
    }
}
