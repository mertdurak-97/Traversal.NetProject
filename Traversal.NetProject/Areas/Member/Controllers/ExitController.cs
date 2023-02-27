using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member,Admin")]
    public class ExitController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public ExitController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> MemberLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", " Login");
        }
    }
}

