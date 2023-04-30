using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
	public class ClassesController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<Class>? c = await DataAccess.GetClassList();
			return View(c);
		}
		public IActionResult Create()
		{			
			return PartialView();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Class c)
		{
			await DataAccess.CreateClass(c);
			return RedirectToAction(nameof(Index));
		}
		
	}
}
