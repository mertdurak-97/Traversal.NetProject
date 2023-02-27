using AutoMapper;
using BusinessLayer.Abstract;
using CoreLayer.DTOs.AnnouncementDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AdminAnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var AnnouncementList = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(AnnouncementList);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO announcementAddDTOs)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Insert(new EntityLayer.Announcement()
                {
                    Content = announcementAddDTOs.Content,
                    Title = announcementAddDTOs.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            _announcementService.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UptadeAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetById(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UptadeAnnouncement(AnnouncementUpdateDTO announcementUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Update(new EntityLayer.Announcement()
                {
                    AnnouncementID = announcementUpdateDTO.AnnouncementID,
                    Content = announcementUpdateDTO.Content,
                    Title = announcementUpdateDTO.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(announcementUpdateDTO);
        }
    }
}