using MailKit.Net.Smtp;
using Medicoz.Application.Contracts.Email;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;
using System.Net;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Reflection.Metadata;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Medicoz.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string messageText)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        string apiKey = Environment.GetEnvironmentVariable("ApiKey");
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress(emailSettings["Username"], "Medicoz"),
            Subject = $"{subject}",
            PlainTextContent = $"{messageText}",
        };
        msg.AddTo(new EmailAddress($"{toEmail}"));

        var response = await client.SendEmailAsync(msg);

       

    }
}
