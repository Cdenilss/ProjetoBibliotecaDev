using MediatR;

namespace ProjetoBiblioteca.Application.Notification.BookCreated;

public class BookNotificationHandler : INotificationHandler<BookCreatedNotification>
{
    public Task Handle(BookCreatedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Livro: {notification.Title} adicionado com sucesso");
        return Task.CompletedTask;
    }
    
}