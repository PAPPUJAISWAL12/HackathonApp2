using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class RoleListsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
