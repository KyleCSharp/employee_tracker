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
        public async Task<IActionResult> Index() 
        {
            var employees =  await _employeeRepo.GetAllEmployeesAsync();

            return View(employees);
        }
        public async Task<IActionResult> ViewId(int id)
        {
            var foundEmployee = await _employeeRepo.GetEmployeeByIdAsync(id);
            return View(foundEmployee);

        }

        
        

        
    }
}
