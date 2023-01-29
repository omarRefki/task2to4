using Microsoft.AspNetCore.Mvc;
using task2.Models;

namespace task2.Controllers
{
    public class dependentController : Controller
    {
        companydbcontext DB = new companydbcontext();
        public IActionResult Index()
        {

            var a = DB.Dependents.ToList();
            return View(a);
        }
        Int32 SSNFromSession;
        public IActionResult GetAllDependent()
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(g => g.EmployeeSSN == SSNFromSession).ToList();
            return View("get_dependent",a);
        }
        public IActionResult addform()
        {
            return View("form");
        }
        public IActionResult addNew(dependent dependent)
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            dependent.EmployeeSSN = SSNFromSession;
            DB.Dependents.Add(dependent);
            DB.SaveChanges();
            TempData["AddMsg"] = "You Add New Dependent";
            return RedirectToAction(nameof(GetAllDependent));
        }
        public IActionResult updateForm()
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(k => k.EmployeeSSN == SSNFromSession).SingleOrDefault();
            return View("update_form",a);
        }
        public IActionResult Deleting(string id)
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(k => k.EmployeeSSN == SSNFromSession && k.name == id).SingleOrDefault();
            DB.Remove(a);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDependent));
        }
        public IActionResult AfterUpdate(dependent editDependent)
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(k => k.EmployeeSSN == SSNFromSession).SingleOrDefault();
            a.sex = editDependent.sex;
            a.relationship = editDependent.relationship;
            a.date = editDependent.date;
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDependent));
        }
    }
}
