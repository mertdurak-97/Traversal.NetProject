using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{


    public class DefaultController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
