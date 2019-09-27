using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace FlightBookingSystem.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "Flybook-Haoran Zhang");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}