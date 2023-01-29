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
                return View("get_department",a);
        }
    }
}
