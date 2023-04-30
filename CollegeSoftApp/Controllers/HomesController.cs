using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CollegeSoftApp.Controllers
{
    public class HomesController : Controller
    {
        private readonly ILogger<HomesController> _logger;

        public HomesController(ILogger<HomesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(User us)
		{
			List<User>? userlist = await DataAccess.GetUserList();			
			if (userlist != null)
			{
				User? u = userlist.Where(u => u.UserEmail.ToUpper().Equals(us.UserEmail.ToUpper()) && u.Upassword.Equals(us.Upassword) && u.LoginStatus == true).FirstOrDefault();				
				if (u != null)
				{
					List<Claim> claims = new List<Claim>
					{
					  new Claim(ClaimTypes.Name,u.UserId.ToString()),
					};
					List<UserRoleView>? role = await DataAccess.GetUserRoleList(u.UserId);
				

					if (role != null)
					{
						var roles = role.Where(r => r.HasRole == 1).ToList();
						foreach (UserRoleView r in roles)
						{
							claims.Add(new Claim(ClaimTypes.Role, r.RoleName));
						}
					}

					ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = us.RememberMe });
					if (us.ReturnUrl == null)
						return RedirectToAction("Index", "Accounts");
					else
						return RedirectToAction(us.ReturnUrl);

				}
			}
			else
			{
				ViewBag.Error = "Login Failed try again!";
			}
			return View(us);
		}


		[Authorize]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}