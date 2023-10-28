namespace Medicoz.Application.Contracts.Email;

public interface IEmailSender
{
    public void SendEmail(string recievers, string subject, string messageText) { }
}
