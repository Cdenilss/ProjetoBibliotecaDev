using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetAllLoans;

public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
{
    
}