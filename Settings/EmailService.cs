using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using MailKit.Security;

namespace TaskSystemServer.Settings
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Tasky Manager", "tasky.mymanager@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress("", email));
                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("plain")
                {
                    Text = message
                };

                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("tasky.mymanager@gmail.com", "dyml dhcb gfei vcan");
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; // Rethrow the exception to propagate it up
            }
        }

    }
}
