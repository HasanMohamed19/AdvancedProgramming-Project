using System.Net.Mail;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace ServiceTitanWebApp.Helpers
{
    public class EmailController
    {
        static EmailController instance;
        private readonly SmtpClient smtpClient;

        private EmailController()
        {
            smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("servicetitanbh@gmail.com", "tdjo fuvx macb ckjm")
            };
        }

        public static EmailController Instance()
        {
            if (instance == null)
            {
                instance = new EmailController();
            }
            return instance;
        }

        public void SendAccountCreatedEmail(string email, string username, string firstName, string lastName)
        {
            string body = $"Hello {firstName} {lastName}. \n You have been registered. \n Your password is Test@123 please login and change it.\n" +
                $"Username: {username}.";

            MailMessage msgMail;
            msgMail = new MailMessage();
            msgMail.From = new MailAddress("servicetitanbh@gmail.com", "serviceTitan");
            msgMail.To.Add(email);

            msgMail.Subject = "Account Created";
            msgMail.Body = body;

            try
            {
                smtpClient.Send(msgMail);
            }
            catch (Exception ex)
            {

            }

            // to relaease the resoruces used by the mail message
            msgMail.Dispose();
        }



    }
}
