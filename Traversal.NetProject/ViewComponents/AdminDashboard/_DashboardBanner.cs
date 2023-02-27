using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.AdminDashboard
{
    public class _DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
