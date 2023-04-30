using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CollegeSoftApp.Controllers
{
    [Authorize]
    public class FeeDetailsController : Controller
    {
        public async Task<IActionResult> Create(int id)
        {

            FeeDetailsView? c = await DataAccess.GetFeeDetails(id);
           
            ViewBag.FeeRemainingAmmount= c.RemainingAmt;
            ViewBag.TotalAmt = c.TotalAmt;
            FeeDetailEdit d = new FeeDetailEdit
            {
                FeeId = c.FeeId,
                EntryDate = DateTime.Today,
                EntryTime = DateTime.UtcNow.AddMonths(345).ToShortTimeString(),
                EntryUserId = Convert.ToInt32(User.Identity.Name)
            };

           /* ViewBag.feelist = new Select(c,nameof(FeeDetailsView.DetailId),nameof(FeeDetailsView.RemainingAmt));
          */
            return View(d);
        }
        [HttpPost]
        public async Task<ActionResult> Create(FeeDetailEdit d)
        {
			string account_sid = "ACcd77da82154aaff843710fa552b92e82";
			string Auth_token = "492196938953b6a4d4426d185a40734b";
			string text = "Paid Ammount";
            string date =Convert.ToString(DateTime.Now);
			string remainingamt = "Remaining Amount";
			TwilioClient.Init(account_sid, Auth_token);
            var messageresource = await MessageResource.CreateAsync(
            body:date+" "+text + " " + d.PaidAmt.ToString() + " " + remainingamt + " " + d.RemainingAmt,
				from: new Twilio.Types.PhoneNumber("+15855951430"),
				to: new Twilio.Types.PhoneNumber("+9779825302105")
				);
            FeePrintView? p = await DataAccess.CreateFeeDetails(d);
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



        public async Task<ActionResult> Details(int id)
        {
            /*if (User.IsInRole("Student"))
            {
                List<FeeDetailsView>? f = await DataAccess.GetFeeDetailsList(Convert.ToInt32(User.Identity.Name));
                return View(f);
            }
            else
            {*/

            FeeDetailsView? s = await DataAccess.GetFeeDetailsBystd(id);
			ViewBag.Fname = s.FullName;
            
            
			ViewBag.Cl = s.Cname;
			ViewBag.YearAmt = s.YearlyAmt;
			ViewBag.Monthlyamt = s.MonthlyFeeAmt;
			ViewBag.YearlyDiscount = s.YearlyDiscount;
			ViewBag.ExamFee = s.Examfee;
			ViewBag.totalamt = s.TotalAmt;

			List<FeeDetailsView>? f = await DataAccess.GetFeeDetailsList(id);
            decimal sum = f.Sum(x => x.PaidAmt);
            ViewBag.paidAmount = sum;
            
			
			return View(f);
            
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            FeeDetail detail = new FeeDetail();
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:7027/api/FeeDetails/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"FeeStatus\", \"value\": \"" + detail.FeeStatus + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);

            }
			return RedirectToAction(nameof(Details));
		}


    }
}
