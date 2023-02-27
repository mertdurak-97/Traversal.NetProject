using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
