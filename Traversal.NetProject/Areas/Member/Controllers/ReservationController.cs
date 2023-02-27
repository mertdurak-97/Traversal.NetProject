using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal.NetProject.Areas.Member.Controllers
{
    [Route("Member/[controller]/[action]/{id?}")]
    [Area("Member")]
    [Authorize(Roles = "Member,Admin")]

    public class ReservationController : Controller
    {

        //DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        //ReservationManager reservationManager = new ReservationManager(new EFReservationDal());

        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;

        public ReservationController(UserManager<AppUser> userManager, IDestinationService destinationService, IReservationService reservationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> MyCurrentReservation() // Şimdiki
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userList = _reservationService.GetListWithReservationByAccepted(user.Id);
            return View(userList);
        }

        public async Task<IActionResult> MyOldReservation() // Eski
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userList = _reservationService.GetListWithReservationByPrevious(user.Id);
            return View(userList);
        }
        public async Task<IActionResult> MyApprovalReservation() //Onay Bekleyen
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userList = _reservationService.GetListWithReservationByWaitAprroval(user.Id);
            return View(userList);
        }

        [HttpGet]
        public IActionResult NewReservation(int id)
        {
            var query = _destinationService.TGetList();
            ViewBag.Destination = new SelectList(query.ToList(), "DestinationID", "City", id);
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Result.Id;
            reservation.Status = "Onay Bekliyor";
            _reservationService.Insert(reservation);
            return RedirectToAction("MyCurrentReservation");
        }


        public IActionResult ReservationAccept(int id)
        {
            var value = _reservationService.TGetById(id);
            value.Status = "Onaylandı";
            _reservationService.Update(value);
            return RedirectToAction("MyApprovalReservation");
        }


    }
}
