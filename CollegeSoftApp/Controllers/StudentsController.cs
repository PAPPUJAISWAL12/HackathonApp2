using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeSoftApp.Controllers
{
    [Authorize]
    public class StudentsController : Controller
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

			return PartialView(s.Where(x => x.Cid == Cid).ToList());
		}

		public async Task<IActionResult> Details(int id)
        {
			if (User.IsInRole("Student"))
			{
				StudentView? std = await DataAccess.GetStudentDetails(Convert.ToInt32(User.Identity.Name));
				return View(std);
			}else
            {
                StudentView? std = await DataAccess.GetStudentDetails(id);
                return View(std);
            }
		}

        public async Task<IActionResult> Create()
        {
			List<Class>? clist = await DataAccess.GetClassList();
			ViewBag.classList = new SelectList(clist, nameof(Class.Cid), nameof(Class.Cname));
			List<RoleList>? rs = await DataAccess.GetRoleList();            
            ViewBag.roleList = new SelectList(rs, nameof(RoleList.RoleId), nameof(RoleList.RoleName));
           
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentEdit edit)
        {
            await DataAccess.CreateStudent(edit);
            return RedirectToAction(nameof(Index));
        }
    }
}
