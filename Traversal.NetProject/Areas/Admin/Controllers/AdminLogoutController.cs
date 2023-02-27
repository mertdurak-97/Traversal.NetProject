using EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLogoutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AdminLogoutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }
    }
}
