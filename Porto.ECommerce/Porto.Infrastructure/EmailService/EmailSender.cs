using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Porto.Application.Contracts.Email;


namespace Porto.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendEmail(string toEmail, string subject, string messageText)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("PRONIA ADMIN", emailSettings["Username"]));

        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = messageText };

        message.To.Add(new MailboxAddress("", toEmail));

        using (var client = new SmtpClient())
        {
            client.Connect(emailSettings["SmtpServer"], int.Parse(emailSettings["SmtpPort"]), false);
            client.Authenticate(emailSettings["Username"], emailSettings["Password"]);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
