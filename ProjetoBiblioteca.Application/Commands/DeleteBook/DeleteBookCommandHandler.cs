using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,ResultViewModel>
{
    private readonly LibraryDbContext _context;

    public DeleteBookCommandHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

        if (book == null)
        {
            return ResultViewModel.Error("Livro Não encontrado");
        }

        book.SetAsDeleted();
        _context.Update(book);
        await _context.SaveChangesAsync();
        return ResultViewModel.Sucess();
    }
}