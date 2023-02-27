using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.AdminDashboard
{
    public class _AdminHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
