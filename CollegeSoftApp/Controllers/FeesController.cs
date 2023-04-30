using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CollegeSoftApp.Controllers
{
	[Authorize]
	public class FeesController : Controller
    {
       
		public async Task<IActionResult> Index()
        {
            List<Class>? c = await DataAccess.GetClassList();
            ViewBag.classList = new SelectList(c, nameof(Class.Cid), nameof(Class.Cname));
            return View();
        }
        
        public async Task<IActionResult> StudentList(int Cid)
        {
            List<StudentView>? s = await DataAccess.GetStudentList();
           
            return PartialView(s.Where(x=>x.Cid==Cid).ToList());
        }




        public async Task<IActionResult> Details(int id)
        {
            FeeDetailsView? fee = await DataAccess.GetFeeDetails(id);
            return PartialView(fee);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            /*      var c = await DataAccess.GetClassDetails(id);*/
            FeeEdit edit = new FeeEdit
            {
                StdId = id,
                EntryUserId = Convert.ToInt32(User.Identity.Name)               
            };
            return PartialView(edit);
        }
        [HttpPost]
       
        public async Task<IActionResult> Create(FeeEdit edit)
        {			          
            try
            {
				string account_sid = "ACcd77da82154aaff843710fa552b92e82";
				string Auth_token = "492196938953b6a4d4426d185a40734b";
				string text = "Paid Ammount";
				string remainingamt = "Remaining Amount";

				TwilioClient.Init(account_sid, Auth_token);
				var messageresource = await MessageResource.CreateAsync(
					body: text + " " + edit.PaidAmt.ToString() + " " + remainingamt + " " + edit.RemainingAmt,
					from: new Twilio.Types.PhoneNumber("+15855951430"),
					to: new Twilio.Types.PhoneNumber("+9779825302105")
					);				
				FeePrintView? p = await DataAccess.CreateFee(edit);
                if (p != null)
                {
					ViewBag.message = "Success";

					return RedirectToAction("Details", "FeePrints", new { id = p.PrintId });
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
