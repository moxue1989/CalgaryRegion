using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace CalgaryHacks.Apis
{
    public class EmailSender
    {
        private static readonly string FromEmail = Environment.GetEnvironmentVariable("email_address");
        private static readonly string Password = Environment.GetEnvironmentVariable("email_password");

        private static readonly NetworkCredential NetworkCredential = new NetworkCredential(FromEmail, Password);

        public static string SendEmail(string emailAddress, string emailTitle, string emailBody)
        {
            if (FromEmail == null || Password == null)
            {
                return "not on cloud";
            }
            return SendEmail(new List<string> { emailAddress }, emailTitle, emailBody);
        }


        public static string SendEmail(List<string> emailAddressList, string emailTitle, string emailBody)
        {
            MailMessage msg = new MailMessage { From = new MailAddress(FromEmail) };
            foreach (string emailAddress in emailAddressList)
            {
                msg.To.Add(emailAddress);
            }
            msg.Subject = emailTitle;
            msg.Body = emailBody;
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = NetworkCredential,
                Timeout = 20000
            };
            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
        }
    }
}