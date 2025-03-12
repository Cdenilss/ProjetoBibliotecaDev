using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProjetoBiblioteca.Infrastructure.Notification;

public class EmailService : IEmailServices
{
    private readonly ISendGridClient _sendGridClient;
    private readonly IConfiguration _configuration;
    private readonly string _fromEmail;
    private readonly string _fromName;
    public EmailService(ISendGridClient sendGridClient, IConfiguration configuration)
    {
        _sendGridClient = sendGridClient;
        _fromEmail = configuration.GetValue<string>("SendGrid:FromEmail");
        _fromName = configuration.GetValue<string>("SendGrid:FromName");
    }
   
    public async Task SendAsync(string email, string subject, string message)
    {
        var msg = new SendGridMessage
        {
            From = new EmailAddress(_fromEmail, _fromName),
            Subject = subject
        };
        msg.AddContent(MimeType.Html, message);
        msg.AddTo(new EmailAddress(email));
        var response= await _sendGridClient.SendEmailAsync(msg);
        
    }
}