using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
