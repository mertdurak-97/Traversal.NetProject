using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class AdminDestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public AdminDestinationController(IDestinationService destinationService)
        {
            this._destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var list = _destinationService.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination, IFormFile image)
        {
            //TODO : Resim yolunda sıkıntı var çözülecek.

            string fileName = null;
            string fileExtension = null;
            string filePath = null;
            bool saveFile = false;
            if (image != null && image.Length > 0)
            {
                fileName = image.FileName;
                fileExtension = Path.GetExtension(fileName);
                saveFile = true;
            }
            if (saveFile)
            {
                fileName = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "") + fileExtension;

                filePath = Path.Combine("wwwroot", "Traversal-Liberty", "images", fileName);

            }
            destination.Image = fileName;
            if (saveFile)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    image.CopyTo(fileStream);
                }
            }
            destination.Status = true;
            _destinationService.Insert(destination);
            return RedirectToAction("Index", "AddDestination");
        }
        public IActionResult DeleteDestination(int id)
        {
            var deleteDestination = _destinationService.TGetById(id);
            _destinationService.Delete(deleteDestination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var UpDestination = _destinationService.TGetById(id);
            return View(UpDestination);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.Update(destination);
            return RedirectToAction("Index");
        }


    }
}
