using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CollegeSoftApp.Controllers
{
    public class ReceptionsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ReceptionView>? r = await DataAccess.GetReception();
      
            return View(r);
        }
		public async Task<IActionResult> CancelList()
		{
			List<ReceptionView>? r = await DataAccess.GetReception();

			return View(r);
		}

		[HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ReceptionView? r = await DataAccess.GetReceptionDetails(id);
            return PartialView(r);
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

        [HttpGet]
        public async Task<IActionResult> Edit(Reception r)
        {

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
			Reception detail = new Reception();
			using (var httpClient = new HttpClient())
			{
				var request = new HttpRequestMessage
				{
					RequestUri = new Uri("https://localhost:7027/api/Receptions/" + id),
					Method = new HttpMethod("Patch"),
					Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"CancelledUserId\", \"value\": \"" + detail.CancelledUserId + "\"},{ \"op\": \"replace\", \"path\": \"CancelledDate\", \"value\": \"" + detail.CancelledDate + "\"},{ \"op\": \"replace\", \"path\": \"ResonForCancell\", \"value\": \"" + detail.ResonForCancell + "\"},{\"op\":\"replace\",\"path\":\"ReceptionStatus\",\"value\": \"" + detail.ReceptionStatus + "\"}]", Encoding.UTF8, "application/json")
				};
				var response = await httpClient.SendAsync(request);
			}		
			return RedirectToAction(nameof(Index));
        }
    }
}
