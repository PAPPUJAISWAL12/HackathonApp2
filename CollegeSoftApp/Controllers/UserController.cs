using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
