using Job.Core.Entities;
using System.Net;
using System.Net.Mail;

namespace Project.Apis.Helpers
{
    public static class EmailSetting
    {
        public static void SendEmail(Email email )
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl= true;
            client.Credentials = new NetworkCredential("mk9996423@gmail.com", "xcfuvblbsbtxpynw");
            client.Send("mk9996423@gmail.com", email.To, email.Subject, email.Body);

        }
    }
}
