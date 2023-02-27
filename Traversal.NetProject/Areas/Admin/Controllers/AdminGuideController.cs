using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminGuideController : Controller
    {
        private readonly IGuideService _guideService;

        public AdminGuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var guideList = _guideService.TGetList();
            return View(guideList);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.Insert(guide);
                return RedirectToAction("Index", "AdminGuide", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var editGuide = _guideService.TGetById(id);
            return View(editGuide);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.Update(guide);
            return RedirectToAction("Index", "AdminGuide");
        }

        public IActionResult DeleteGuide(int id)
        {
            var guideDelete = _guideService.TGetById(id);
            _guideService.Delete(guideDelete);
            return RedirectToAction("Index");
        }
    }
}
