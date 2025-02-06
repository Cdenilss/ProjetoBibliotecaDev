using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.BookQueries.GetBooksById;

public class GetBookByIdQueriesHandler : IRequestHandler<GetBookByIdQueries,ResultViewModel<BookViewModel>>
{
    private readonly LibraryDbContext _context;

    public GetBookByIdQueriesHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQueries request, CancellationToken cancellationToken)
    {
       
        var books = await _context.Books
            .Include(b => b.Loans)
            .SingleOrDefaultAsync(b => b.Id == request.Id);

        if (books == null)
        {
            return ResultViewModel<BookViewModel>.Error("Livro Não Encontrado");
        }

        var model = BookViewModel.FromEntity(books);
        return ResultViewModel<BookViewModel>.Sucess(model);

    }
}