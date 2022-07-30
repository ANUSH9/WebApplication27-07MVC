using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication27_07.data;
using WebApplication27_07.Models;

namespace WebApplication27_07.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<IActionResult> Index()
        {
            var employee = await _employeeContext.Employees.ToListAsync();
            return View(employee);
        }
        public IActionResult CreateNewEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _employeeContext.Employees.Add(employee);
                await _employeeContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id<=0)
            {
                return BadRequest();
            }
            var employeeInDb= await _employeeContext.Employees.SingleOrDefaultAsync(e=>e.ID==id);
            if(employeeInDb==null)
            {
                return NotFound();

            }
            return View(employeeInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
                _employeeContext.Employees.Update(employee);
                await _employeeContext.SaveChangesAsync();
                return RedirectToAction("Index");

            
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var employeeInDb = await _employeeContext.Employees.FirstOrDefaultAsync(p => p.ID == id);
            if (employeeInDb == null)
            {
                return NotFound();

            }
            _employeeContext.Employees.Remove(employeeInDb);
            await _employeeContext.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)

        {
            ViewData["CreateNewEmployee"] = searchString;
            var movies = from s in _employeeContext.Employees select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Firstname!.Contains(searchString)|| s.City!.Contains(searchString)|| s.MobileNo!.Contains(searchString));
            }

            return View(await movies.AsNoTracking().ToListAsync());
        }


    }
}
