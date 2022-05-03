using dormitoryApps.Shared.Model.Other;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace dormitoryApps.Server.Services
{
    public interface IEmailServices
    {
        Task SendAsync(MailRequest request);
    }
    public class EmailService : IEmailServices
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendAsync(MailRequest request)
        {
            Console.WriteLine(1000);
            string sender = _configuration.GetSection("Email:Name").Value;
            string password = _configuration.GetSection("Email:Password").Value;
            string host = _configuration.GetSection("Email:Host").Value;
            int port = int.Parse( _configuration.GetSection("Email:Port").Value);
            MimeMessage email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(sender);
            foreach (var to in request.ToEmail)
            {
                email.To.Add(MailboxAddress.Parse(to));
            }
            if (request.CC != null)
            {
                foreach (var cc in request.CC)
                {
                    email.Cc.Add(MailboxAddress.Parse(cc));
                }
            }
            var builder = new BodyBuilder();
            if (request.Attachments != null)
            {
                foreach (var attachment in request.Attachments)
                {
                    builder.Attachments.Add(attachment.FileName, attachment.Content, ContentType.Parse(attachment.ContentType));
                }
            }
            builder.HtmlBody = request.Body;
            email.Subject = request.Subject;
            email.Body = builder.ToMessageBody();          
           //  MailAddress address = new MailAddress(sender,request.DisplayName);
           //  email.From.Add(address);
            var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(host, port);
            await smtp.AuthenticateAsync(sender, password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
