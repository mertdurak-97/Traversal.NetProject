using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal.NetProject.Models;

namespace Traversal.NetProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequestModel mailRequestModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "alp.mertt06@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            //Yukardan gelen kullancının mailini ekle dedik.
            //Bu Kimden geldi kutusu şimdi kime göndereceğimizi(Alıcı) yazacağız.
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequestModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequestModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequestModel.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("alp.mertt06@gmail.com", "hxrtmbmcqefgsmgt");//Şifrenin olduğu kısım
            client.Send(mimeMessage);//mimeMessage'daki mesajı yolla
            client.Disconnect(true);
            return View("Index");

        }

    }
}
