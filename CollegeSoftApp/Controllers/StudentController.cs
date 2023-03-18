using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
