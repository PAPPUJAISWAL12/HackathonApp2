using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class TeachersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<TeacherView>? teacherList = await DataAccess.GetTeacherList(); 
            return View(teacherList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherEdit edit)
        {
            TeacherEdit t = await DataAccess.CreateTecaher(edit);
            return RedirectToAction(nameof(Index));
        }
    }
}
