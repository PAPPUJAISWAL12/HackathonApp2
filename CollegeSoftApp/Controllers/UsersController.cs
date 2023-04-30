using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
