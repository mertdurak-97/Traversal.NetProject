using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.Comment
{
    public class _CommentListPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        AddDbContext c = new AddDbContext();

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.CommentCount = c.Comments.Where(x => x.DestinationID == id).Count();
            var values = _commentService.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
