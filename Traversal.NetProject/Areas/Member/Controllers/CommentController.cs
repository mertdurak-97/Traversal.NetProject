using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        [Area("Member")]
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
