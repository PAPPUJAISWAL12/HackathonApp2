using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class FeesController : Controller
    {
        public async Task<IActionResult> Index()
        {
        
            List<FeeDetailsView>? fee = await DataAccess.GetFeeList();
            return View(fee);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            FeeDetailsView? fee = await DataAccess.GetFeeDetails(id);
            return PartialView(fee);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {

        }
    }
}
