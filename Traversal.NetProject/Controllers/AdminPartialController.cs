using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{
    [Area("Admin")]
    public class AdminPartialController : Controller
    {
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult DashboardPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
    }
}
