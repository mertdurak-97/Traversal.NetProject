using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public AdminUserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }


        public IActionResult Index()
        {
            var appUserList = _appUserService.TGetList();
            return View(appUserList);
        }

        public IActionResult DeleteUser(int id)
        {
            var userDelete = _appUserService.TGetById(id);
            _appUserService.Delete(userDelete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var userEdit = _appUserService.TGetById(id);
            return View(userEdit);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.Update(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult ReservationUser(int id)
        {
            var userReservation = _reservationService.GetListWithReservationByAccepted(id);
            return View(userReservation);
        }
    }
}
