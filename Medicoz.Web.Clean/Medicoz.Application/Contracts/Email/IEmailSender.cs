namespace Medicoz.Application.Contracts.Email;

public interface IEmailSender
{
    Task SendEmailAsync(string recievers, string subject, string messageText);
}
