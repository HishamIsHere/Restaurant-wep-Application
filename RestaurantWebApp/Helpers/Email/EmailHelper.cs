using MailKit.Net.Smtp;
using MimeKit;
using WebAppTemplate.ViewModels;

namespace WebAppTemplate.Helpers.Email
{
    public class EmailHelper : IEmailHelper
    {
        public void SendMessage(EmailViewModel model)
        {
            //Email Settings
            //Message
            var FromEmail = "YOUREMAIL@gmail.com";
            var AppPassword = "YOURPASSWORD";
            var SMTPServer = "smtp.gmail.com";
            var SMTPPort = 465;
            //Email Message
            var EmailMessage = new MimeMessage();
            EmailMessage.From.Add(new MailboxAddress("YOURNAME", FromEmail));
            EmailMessage.To.Add(MailboxAddress.Parse(model.EmailAddress));
            EmailMessage.Subject = model.Subject;
            EmailMessage.Body = new TextPart("plain") { Text = model.Message };
            //send Email
            var client = new SmtpClient();
            client.Connect(SMTPServer, SMTPPort, MailKit.Security.SecureSocketOptions.SslOnConnect);
            client.Authenticate(FromEmail, AppPassword);
            client.Send(EmailMessage);
            client.Disconnect(true);
        }
    }
}
