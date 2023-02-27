using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.ViewComponents.AdminDashboard
{
    public class _DestinationStatistic : ViewComponent
    {
        //DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        public IViewComponentResult Invoke()
        {
            //var destination = destinationManager.TGetList();
            return View();
        }
    }
}
