using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.Default
{
    public class _PopularDestinationsPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _PopularDestinationsPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
    }
}
