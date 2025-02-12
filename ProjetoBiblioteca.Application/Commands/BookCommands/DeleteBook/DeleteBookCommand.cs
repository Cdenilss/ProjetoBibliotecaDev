using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;

public class DeleteBookCommand :  IRequest<ResultViewModel>
{
    public DeleteBookCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}