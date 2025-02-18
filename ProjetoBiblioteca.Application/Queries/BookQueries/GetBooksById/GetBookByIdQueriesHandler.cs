using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.BookQueries.GetBooksById;

public class GetBookByIdQueriesHandler : IRequestHandler<GetBookByIdQueries,ResultViewModel<BookViewModel>>
{
    private readonly IBookRepository _repository;

    public GetBookByIdQueriesHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQueries request, CancellationToken cancellationToken)
    {

        var books = await _repository.GetDetailsById(request.Id);

        if (books == null)
        {
            return ResultViewModel<BookViewModel>.Error("Livro Não Encontrado");
        }

        var model = BookViewModel.FromEntity(books);
        return ResultViewModel<BookViewModel>.Sucess(model);

    }
}