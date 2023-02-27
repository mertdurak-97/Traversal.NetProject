
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        AddDbContext addDBContext = new AddDbContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v = addDBContext.Destinations.Count();
            ViewBag.v1 = addDBContext.Users.Count();
            return View();
        }
    }
}
