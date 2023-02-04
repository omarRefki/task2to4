using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Edit()
        {
            List<employee> employees = DB.employees.ToList();
            ViewBag.employees = new SelectList(employees, "SSN", "Fname");
            return View();
        }
        public IActionResult Edit_emp(int id)
        {
            List<project>? projects = DB.WorkOns.Include(w => w.Project).Where(w => w.ESSN == id).Select(w => w.Project).ToList();
            ViewBag.projects = new SelectList(projects, "Pnumber", "Name");
            if (projects.Count > 0)
            {
                workon worksOnProject = new workon();
                return PartialView("_ProjectsList");
            }
            return PartialView("_ProjectsList");
        }

        public IActionResult Edit_emp_proj(int id, int Pnum)
        {
            workon? worksOnProject = DB.WorkOns.SingleOrDefault(w => w.ESSN == id && w.Pnum == Pnum);
            return PartialView("_hour", worksOnProject);
        }
    }
}
