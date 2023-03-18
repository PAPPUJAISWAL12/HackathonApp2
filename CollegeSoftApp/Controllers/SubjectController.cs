using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
