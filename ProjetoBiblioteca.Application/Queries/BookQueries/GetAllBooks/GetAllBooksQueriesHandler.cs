using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.BookQueries.GetAllBooks;

public class GetAllBooksQueriesHandler: IRequestHandler<GetAllBooksQueries,ResultViewModel<List<BookItemViewModel>>>
{
    private readonly LibraryDbContext _context;

    public GetAllBooksQueriesHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksQueries request, CancellationToken cancellationToken)
    {
        var books = await _context.Books
            .Where(b => !b.IsDeleted).ToListAsync();

        if (books == null)
        {
            return ResultViewModel<List<BookItemViewModel>>.Error("Lista de Livros Vazia");
        }

        var model = books.Select(b => BookItemViewModel.FromEntity(b)).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Sucess(model);
    }
}