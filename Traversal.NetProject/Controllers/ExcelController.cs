using ClosedXML.Excel;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Traversal.NetProject.Models;

namespace Traversal.NetProject.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public List<DestinationExcelModel> DestinationExcelList()
        {
            List<DestinationExcelModel> destinationExcelModels = new List<DestinationExcelModel>();
            using (var c = new AddDbContext())
            {
                destinationExcelModels = c.Destinations.Select(x => new DestinationExcelModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity,
                }).ToList();
                return destinationExcelModels;
            }
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2; //Excelde ilk satırdan aşağısı itibaren yazdırmaya başlşayacak.
                foreach (var item in DestinationExcelList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Yeni Liste.xlsx");
                }
            }
        }
    }
}
