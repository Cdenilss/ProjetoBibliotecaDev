using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.BookQueries.GetAllBooks;

public class GetAllBooksQueriesHandler: IRequestHandler<GetAllBooksQueries,ResultViewModel<List<BookItemViewModel>>>
{
    
    private readonly IBookRepository _repository;

    public GetAllBooksQueriesHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksQueries request, CancellationToken cancellationToken)
    {
        var books = await _repository.GetAll();

        if (books == null)
        {
            return ResultViewModel<List<BookItemViewModel>>.Error("Lista de Livros Vazia");
        }

        var model = books.Select(b => BookItemViewModel.FromEntity(b)).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Sucess(model);
    }
}