using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;

namespace task2.Controllers
{
    public class departmentController : Controller
    {
       companydbcontext DB = new companydbcontext();
        public IActionResult GetDeptByMgrId(int id)
        {
            var a = DB.Departments.Include(d => d.DLocations).Include(d => d.Projects).SingleOrDefault(d => d.MangerId == id);

            if (a == null)
                return View("Error");
            else
                return View("get_department", a);
        }
        public IActionResult allDepartments()
        {
            var a = DB.Departments.ToList();
            return View(a);
        }
        public IActionResult details(int id)
        {
            var a = DB.Departments.Where(x => x.Dnum == id).SingleOrDefault();

            return View(a);
        }
        public IActionResult addform()
        {
            return View();
        }
        public IActionResult add(department d)
        {
            DB.Departments.Add(d);
            DB.SaveChanges();

            return RedirectToAction(nameof(allDepartments));
        }
        public IActionResult editform(int id)
        {
            var a = DB.Departments.Where(x => x.Dnum == id).SingleOrDefault();


            return View(a);
        }
        public IActionResult edit(department d)
        {
            var a = DB.Departments.Where(x => x.Dnum == d.Dnum).SingleOrDefault();

            a.DName = d.DName;
            DB.SaveChanges();

            return RedirectToAction(nameof(allDepartments));
        }
        public IActionResult delete(int id)
        {
            var a = DB.Departments.SingleOrDefault(d => d.Dnum == id);
            DB.Departments.Remove(a);
            DB.SaveChanges();
            return RedirectToAction(nameof(allDepartments));

        }
    }
}
