using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList_SearchBar.PagedList;
using PagedList_SearchBar.Validations;

namespace PagedList_SearchBar.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<Employee> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Employees.Where(employee => employee.FirstName.Contains(searchText) || employee.LastName.Contains(searchText) ||
                employee.City.Contains(searchText) || employee.Age.ToString().Contains(searchText) ||
                employee.Wage.ToString().Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Employees.Where(employee => employee.FirstName.Contains(searchText) || employee.LastName.Contains(searchText) ||
                employee.City.Contains(searchText) || employee.Age.ToString().Contains(searchText) ||
                employee.Wage.ToString().Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Employees.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Employee";
            ViewBag.actionName = "EmployeeList";
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            Context context = new Context();
            EmployeeValidator employeeValidator = new EmployeeValidator();
            var result = employeeValidator.Validate(employee);
            if (result.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
