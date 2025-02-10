using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Application.Services.Queries.LoanQuery.GetAllLoans;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetLoanById;

public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
{
    public GetLoanByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}