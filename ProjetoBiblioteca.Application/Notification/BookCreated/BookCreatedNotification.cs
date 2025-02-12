using MediatR;

namespace ProjetoBiblioteca.Application.Notification.BookCreated;

public class BookCreatedNotification : INotification
{
    public int Id { get; set; }
    
    public string Title { get; set; }
}