using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
