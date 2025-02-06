using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Queries.BookQueries.GetBooksById;

public class GetBookByIdQueries: IRequest<ResultViewModel<BookViewModel>>
{
    public GetBookByIdQueries(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}