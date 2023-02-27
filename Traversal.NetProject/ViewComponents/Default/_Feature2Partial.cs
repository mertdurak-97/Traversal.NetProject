using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.Default
{
    public class _Feature2Partial : ViewComponent
    {
        private readonly IFeature2Service _feature2Service;

        public _Feature2Partial(IFeature2Service feature2Service)
        {
            _feature2Service = feature2Service;
        }
        public IViewComponentResult Invoke()
        {
            var values = _feature2Service.TGetList();
            return View(values);
        }
    }
}
