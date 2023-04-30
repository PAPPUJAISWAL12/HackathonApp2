using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class FeePrintsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            FeePrintView? print = await DataAccess.GetFeePrintDetails(id);
            return View(print);
        }
    }
}
