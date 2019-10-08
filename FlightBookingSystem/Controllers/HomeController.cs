using FlightBookingSystem.Models;
using FlightBookingSystem.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;



namespace FlightBookingSystem.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Offers()
        {
            return View();
        }
        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    
                    EmailSender es = new EmailSender();
                   
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }


        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Email(SendEmailViewModel model, List<HttpPostedFileBase> attachments)
        {
            

            string from = "haoranbackup4@gmail.com"; 

            using (MailMessage mm = new MailMessage(from, model.ToEmail))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Contents;
                foreach (HttpPostedFileBase attachment in attachments)
                {
                    if (attachment != null)
                    {
                        string fileName = Path.GetFileName(attachment.FileName);
                        mm.Attachments.Add(new Attachment(attachment.InputStream, fileName));
                    }
                }
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from, "zhr1994121");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ViewBag.Message = "Email sent.";
            }

            return View();
        }
    }
}