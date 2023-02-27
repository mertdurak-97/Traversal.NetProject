using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member,Admin")]
    public class MemberDestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public MemberDestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
    }
}
