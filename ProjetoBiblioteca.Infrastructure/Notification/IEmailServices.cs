namespace ProjetoBiblioteca.Infrastructure.Notification;

public interface IEmailServices
{
    Task SendAsync(string email, string subject, string message);
    
}