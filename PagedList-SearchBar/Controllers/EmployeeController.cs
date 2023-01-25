using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList_SearchBar.PagedList;
using PagedList_SearchBar.Validations;

namespace PagedList_SearchBar.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            TempData["page"] = page;
            int pageSize = 2;
            Context context = new Context();
            Pager pager;
            List<Employee> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = context.Employees.Where(employee => employee.FirstName.Contains(searchText) || employee.LastName.Contains(searchText) ||
                employee.City.Contains(searchText) || employee.Age.ToString().Contains(searchText) ||
                employee.Wage.ToString().Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = context.Employees.Where(employee => employee.FirstName.Contains(searchText) || employee.LastName.Contains(searchText) ||
                employee.City.Contains(searchText) || employee.Age.ToString().Contains(searchText) ||
                employee.Wage.ToString().Contains(searchText)).ToList().Count;
            }
            else
            {
                data = context.Employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = context.Employees.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Employee";
            ViewBag.actionName = "Index";
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
            EmployeeValidator employeeValidator = new EmployeeValidator();
            var result = employeeValidator.Validate(employee);
            if (result.IsValid)
            {
                employeeManager.EmployeeInsert(employee);
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

        public IActionResult Delete(int id)
        {
            Employee employee = employeeManager.EmployeeGetById(id);
            employee.IsActive= false;
            employeeManager.EmployeeUpdate(employee);
            int page = (int)TempData["page"];
            return RedirectToAction("Index",new {page,searchText=""});
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Employee employee = employeeManager.EmployeeGetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            EmployeeValidator employeeValidator=new EmployeeValidator();
            var result=employeeValidator.Validate(employee);    
            if(result.IsValid)
            {
                employeeManager.EmployeeUpdate(employee);
                int page = (int)TempData["page"];
                return RedirectToAction("Index", new { page, searchText = "" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(employee);
            }
        }
    }
}
