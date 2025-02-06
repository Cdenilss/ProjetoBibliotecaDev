using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Queries.BookQueries.GetAllBooks;

public class GetAllBooksQueries: IRequest<ResultViewModel<List<BookItemViewModel>>>
{
    
}