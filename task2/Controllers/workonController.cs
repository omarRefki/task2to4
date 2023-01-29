using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;

namespace task2.Controllers
{
    public class workonController : Controller
    {
        private companydbcontext DB = new companydbcontext();
      
        public IActionResult AddEmployees(int id)
        {
            List<project> projects = DB.Projects.Where(p => p.DepartmentDnum == id).ToList();
            List<employee> employees = DB.employees.Where(p => p.SSN == id).ToList();

            ViewBag.emps = employees;

            return View("add_employe",projects);
        }

        workon worksOnProject1;
        public IActionResult afterAdd(List<int> Projects, List<int> Employees)
        {

            foreach (var Project in Projects)
            {
                foreach (var employee in Employees)
                {
                    workon worksOnProject = new workon()
                    {
                        ESSN = employee,
                        Pnum = Project
                    };
                    worksOnProject1 = DB.WorkOns.Include(w => w.Project).SingleOrDefault(w => w.ESSN == worksOnProject.ESSN);
                    DB.WorkOns.Add(worksOnProject);
                    DB.SaveChanges();
                }

            }

            ViewBag.emps = Employees;
            ViewBag.mgrSSN = (int)HttpContext.Session.GetInt32("SSN");

            return View("return_page",worksOnProject1);
        }
    }
}
