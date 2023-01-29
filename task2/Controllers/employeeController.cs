using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;

namespace task2.Controllers
{
    public class employeeController : Controller
    {
        companydbcontext DB = new companydbcontext();
        public IActionResult Index()
        {
            var a = DB.employees.ToList();
            return View("newemployee",a);
        }

        public IActionResult user_details()
        {
            var id = HttpContext.Session.GetInt32("SSN");
            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();

            return View("emp_details",a);
        }
        public IActionResult getinfo(int id)
        {
            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();

            return View("get_info",a);
        }

        public IActionResult addform()
        {
            var a = DB.employees.ToList();
            return View("form",a);
        }

        public IActionResult addnew(employee emp)
        {
            if(emp.Fname != null && emp.Lname != null && emp.SSN != null && emp.salary != null && emp.address != null)
            {
                var a = DB.employees.ToList();
                DB.employees.Add(emp);
                DB.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(addform));
        }

        public IActionResult delete(int id)
        {
            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();

            DB.employees.Remove(a);
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult editform(int id)
        {
            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();

            return View("edit_info",a);
        }

        public IActionResult afteredit(employee emp)
        {
            var a = DB.employees.Where(x => x.SSN == emp.SSN).SingleOrDefault();
            a.Fname = emp.Fname;
            a.Lname = emp.Lname;
            a.salary = emp.salary;
            a.superid = emp.superid;
            a.sex = emp.sex;
            a.address = emp.address;
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult logging(employee empLogin)
        {

            employee emppp = DB.employees.Where(x => x.SSN == empLogin.SSN && x.Fname == empLogin.Fname).SingleOrDefault();
            if (emppp == null)
            {
                return View("error");
            }
            else
            {
                HttpContext.Session.SetInt32("SSN", empLogin.SSN);
                return RedirectToAction(nameof(user_details));
            }
        }
        public IActionResult manager()
        {
            var a = DB.Departments.Include(e => e.Employee).Where(e => e.MangerId != null).Select(e => e.Employee.Fname).ToList();

            return View("manager",a);
        }
    }
}
