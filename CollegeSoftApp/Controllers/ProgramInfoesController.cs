using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CollegeSoftApp.Controllers
{
    public class ProgramInfoesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PrograInfoView>? p = await DataAccess.GetProgramInfo();
           
            return View(p);
        }
        [HttpGet]
        public IActionResult create()
        {
            ProgramInfoEdit edit = new ProgramInfoEdit
            {
                EntryDate = DateTime.Today,
                UserId = Convert.ToInt32(User.Identity.Name),
                StartDate=DateTime.Today,
                EndDate=DateTime.Today

            };
            return PartialView(edit);
        }

        

        [HttpPost]
        public async Task<IActionResult> create(ProgramInfoEdit program)
        {
            try
            {
				string account_sid = "ACcd77da82154aaff843710fa552b92e82";
				string Auth_token = "492196938953b6a4d4426d185a40734b";
				string text = "School Event Name";
                string des = "Description";
				
				
				TwilioClient.Init(account_sid, Auth_token);
				var messageresource = await MessageResource.CreateAsync(
				body: program.StartDate + " " + text + " " + program.Pname + " " + des + " " + program.Pdescription,
					from: new Twilio.Types.PhoneNumber("+15855951430"),
					to: new Twilio.Types.PhoneNumber("+9779825302105")
					);
				await DataAccess.CreateProgramInfo(program);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            await DataAccess.GetProgramInfoDetails(id);
            return PartialView();
        }
       
    }
}
