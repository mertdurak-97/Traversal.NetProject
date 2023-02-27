using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Controllers
{
    public class PricingController : Controller
    {
        private readonly IDestinationService _destinationService;

        public PricingController(IDestinationService destinationService)
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
