using Microsoft.AspNetCore.Mvc;
using task2.Models;

namespace task2.Controllers
{
    public class projectController1 : Controller
    {
        companydbcontext DB = new companydbcontext();
        public IActionResult allProjects(int id)
        {
            var a = DB.Projects.ToList();
            return View(a);
        }

        [HttpGet]
        public IActionResult addform()
        {
            ViewBag.department = DB.Departments.ToList();
            return View("project_form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(VMproject p)
        {
            if (ModelState.IsValid)
            {
                project proj = new project()
                {
                    Name = p.Name,
                    Pnumber = p.Pnumber,
                    location = p.location
                };
                DB.Projects.Add(proj);
                DB.SaveChanges();
                return RedirectToAction(nameof(allProjects));
            }
            else
            {
                return View();
            }
        }
    }
}
