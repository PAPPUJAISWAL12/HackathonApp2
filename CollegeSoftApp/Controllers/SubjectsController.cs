using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class SubjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
