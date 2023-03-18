using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class ReceptionController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ReceptionView>? receptionViews = await DataAccess.GetReception();
            return View(receptionViews);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ReceptionView? receptionView = await DataAccess.GetReceptionDetails(id);
            return PartialView();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ReceptionEdit edit = new ReceptionEdit
            {
                EntryDate = DateTime.Now,
                EntryTime = DateTime.UtcNow.AddMinutes(345).ToShortTimeString(),
                UserId = Convert.ToInt32(User.Identity.Name)
            };            
            return PartialView(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceptionEdit reception)
        {
            await DataAccess.CreateReception(reception);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
