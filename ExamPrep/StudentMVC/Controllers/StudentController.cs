using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            IEnumerable<Student> students = Student.GetAllStudents();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student student = Student.GetStudent(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Student student = new Student
                {
                    RollNo = int.Parse(collection["RollNo"]),
                    Name = collection["Name"],
                    Subject = collection["Subject"],
                    Marks = decimal.Parse(collection["Marks"])
                };
                Student.Create(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = Student.GetStudent(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Student student = new Student
                {
                    RollNo = int.Parse(collection["RollNo"]),
                    Name = collection["Name"],
                    Subject = collection["Subject"],
                    Marks = decimal.Parse(collection["Marks"])
                };
                Student.Update(id, student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = Student.GetStudent(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Console.WriteLine(id);
            try
            {
               
                Student.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
