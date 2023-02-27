using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{


    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userMananager;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userMananager)
        {
            _destinationService = destinationService;
            _userMananager = userMananager;
        }


        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.Id = id;
            ViewBag.destID = id; //Arka planda seçili olan Destination bilgisine göre yorumu ekleme
            var value = await _userMananager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id; //sisteme kayıtlı olan x numaralı kullanıcının yorumunu arka planda Id'sini gizleyip sadece yorumunu ada göre gösterme işlemi.
            var details = _destinationService.TGetById(id);
            return View(details);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }

    }
}
