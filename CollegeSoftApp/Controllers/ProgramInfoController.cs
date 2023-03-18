using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class ProgramInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
