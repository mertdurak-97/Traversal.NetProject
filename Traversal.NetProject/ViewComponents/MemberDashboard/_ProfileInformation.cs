using EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.MemberDashboard
{
    public class _ProfileInformation : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync() //Componentte async kullanmak için metotu InvokeAsync çevir
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.User = user.Name + " " + user.Surname;
            ViewBag.Phone = user.PhoneNumber;
            ViewBag.Mail = user.Email;
            return View();
        }
    }
}
