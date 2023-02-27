using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactUs contactUs)
        {
            contactUs.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            contactUs.MessageStatus = true;
            _contactUsService.Insert(contactUs);
            return RedirectToAction("Index", "Default");
        }

    }
}
