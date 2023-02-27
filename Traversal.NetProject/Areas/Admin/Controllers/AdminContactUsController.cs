using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class AdminContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public AdminContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var contactList = _contactUsService.TGetList();
            return View(contactList);
        }
        public IActionResult DeleteContact(int id)
        {
            var contactDelete = _contactUsService.TGetById(id);
            _contactUsService.Delete(contactDelete);
            return RedirectToAction("Index", "AdminContactUs");
        }
    }
}
