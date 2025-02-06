using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.InsertBook;

public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand,ResultViewModel<int>>
{
    private readonly LibraryDbContext _context;

    public InsertBookCommandHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {

            var book = request.ToEntity();
         await _context.Books.AddAsync(book);
          await  _context.SaveChangesAsync();
          return ResultViewModel<int>.Sucess(book.Id);
    }
}