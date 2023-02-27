using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public AdminCommentController(ICommentService commentService, UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var commentList = _commentService.TGetListCommentWithDestination();
            for (int i = 0; i < commentList.Count; i++)
            {
                var destinationDetail = _destinationService.TGetById(commentList[i].DestinationID);
                commentList[i].Destination = destinationDetail;

            }
            return View(commentList);
        }
        public IActionResult DeleteComment(int id)
        {

            var user = _commentService.TGetById(id);
            _commentService.Delete(user);
            return RedirectToAction("Index", "AdminComment");
        }
    }
}
