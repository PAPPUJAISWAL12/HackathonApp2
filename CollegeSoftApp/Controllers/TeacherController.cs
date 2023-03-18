using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
