using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
	[Authorize]
	public class AccountsController : Controller
	{
		public IActionResult Index()
		{
			if (User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Users");
			}
			else if (User.IsInRole("Student"))
			{
				return RedirectToAction("Details","Students");
			}
			else if (User.IsInRole("Teacher"))
			{
				return RedirectToAction("Index", "Teachers");
			}
			else if (User.IsInRole("Accountant"))
			{
				return RedirectToAction("Index","Fees");
			}
			else
			{
				return RedirectToAction("Index", "");
			}
		}
	}
}
