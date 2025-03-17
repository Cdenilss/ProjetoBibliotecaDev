using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,ResultViewModel>
{
    private readonly IBookRepository _repository;

    public DeleteBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetById(request.Id);

        if (book == null)
        {
            return ResultViewModel.Error("Livro Não encontrado");
        }

        book.SetAsDeleted();
        book.MakesUnavailable();
        await _repository.Update(book);
        return ResultViewModel.Success();
    }
}