using FirstCrudMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FirstCrudMVC.ViewModels;

namespace FirstCrudMVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController1
        public ActionResult Index()
        {
            List<Employee> employees = Employee.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeesController1/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = Employee.GetEmployee(id);
            return View(employee);
        }

        // GET: EmployeesController1/Create
        public ActionResult Create()
        {
            EmployeeView o = new EmployeeView();
            List<SelectListItem> objDepts = new List<SelectListItem>() ;
            foreach (Department item in Department.GetAllDepartments())
            {
                SelectListItem obj = new SelectListItem(item.DeptName, item.DeptNo.ToString(),item.DeptName=="HR");
                objDepts.Add(obj);
            }

            o.Departments = objDepts;

            ViewBag.Departments = objDepts;

            return View(o);
        }

        // POST: EmployeesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {  
            try
            {
                Employee.Create(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController1/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = Employee.GetEmployee(id);
            return View(employee);
        }

        // POST: EmployeesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                Employee.Update(id, emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController1/Delete/5
        public ActionResult Delete(int id=0)
        {
            Employee employee = Employee.GetEmployee(id);
            return View(employee);
        }

        // POST: EmployeesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
