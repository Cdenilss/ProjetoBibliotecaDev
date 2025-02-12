using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetLoanById;

public class GetLoanByIdQuery : IRequest<ResultViewModel<LoanViewModel>>
{
    public GetLoanByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}