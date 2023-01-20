using Microsoft.AspNetCore.Mvc;

namespace employee_tracker.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
