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
            var employees = await _employeeRepo.GetAllEmployeesAsync();

            return View(employees);
        }

        public async Task<IActionResult> ViewId(int id)
        {
            var foundEmployee = await _employeeRepo.GetEmployeeByIdAsync(id);
            return View(foundEmployee);

        }

        public async Task<IActionResult> UpdateEmployeeAsync(int id)
        {
            var employessUpdate = await _employeeRepo.GetEmployeeByIdAsync(id);

            return View(employessUpdate);
        }

        public async Task<IActionResult> UpdateEmployeeToDataBaseAsync(Employee employee)
        {
            var updateProcess = await _employeeRepo.UpdateEmployeeAsync(employee);
            return RedirectToAction("ViewID", new { id = employee.ID });
        }
        public IActionResult InsertEmployee()
        {
            return View("InsertEmployee", new Employee());
        }
        public async Task<IActionResult> InsertEmployeeToDataBaseAsync(Employee employee)
        {
            var idInserted = await _employeeRepo.AddEmployeeAsync(employee);
            if (idInserted == 0)
            {
                return View("ErrorPage");
            }
            return RedirectToAction("ViewID", new { id = idInserted });
        }
        public async Task<IActionResult> DeleteEmployeeFromDataBase(Employee employee)
        {
            var deletePerson = await _employeeRepo.DeleteEmployeeAsync(employee.ID);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SeachForEmployeesFromDataBase(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return View("ErrorPage");
            }

            var foundEmployee = await _employeeRepo.GetEmployeesByNameAsync(name);


            if (foundEmployee == null)
            {
                return View("ErrorPage");
            }

            return View("SearchForEmployeesFromDataBase", foundEmployee);


        }

    }
}
