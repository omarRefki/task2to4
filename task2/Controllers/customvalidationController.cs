using Microsoft.AspNetCore.Mvc;

namespace task2.Controllers
{
    public class customvalidationController : Controller
    {
        public IActionResult locationName(string location)
        {
            if (location.Contains("cairo") || location.Contains("giza") || location.Contains("alex"))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
