using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class RoleListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
