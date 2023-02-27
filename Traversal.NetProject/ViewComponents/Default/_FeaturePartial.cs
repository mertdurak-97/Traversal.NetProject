using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeaturePartial(IFeatureService featureService)
        {
            _featureService = featureService;

        }
        public IViewComponentResult Invoke()
        {
            var values = _featureService.TGetList();
            return View(values);
        }
    }
}
