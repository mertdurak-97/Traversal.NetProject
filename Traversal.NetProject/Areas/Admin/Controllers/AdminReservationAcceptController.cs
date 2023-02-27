using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminReservationAcceptController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public AdminReservationAcceptController(IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }

        // TODO : Rezarvasyon sadece ID=1 Olanın bilgilerini getiriyor.


        [HttpGet]
        public async Task<IActionResult> MyApprovalReservation2() //Onay Bekleyen
        {
            var values = _reservationService.GetAllApprovalReservations();
            return View(values);
        }
        public IActionResult ReservationAccept(int id)
        {
            var reservaiton = _reservationService.TGetById(id);
            reservaiton.Status = "Onaylandı";
            _reservationService.Update(reservaiton);
            return RedirectToAction("MyApprovalReservation2");

        }

    }
}
