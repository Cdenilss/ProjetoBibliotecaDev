using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetAllLoans;

public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery,ResultViewModel<List<LoanViewModel>>>
{
    private readonly ILoanRepository _repository;

    public GetAllLoansQueryHandler(ILoanRepository repository)
    {
       _repository=repository;
    }

    public  async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
        var loan = await _repository.GetAll();

        if (loan==null) 
        {
            return ResultViewModel<List<LoanViewModel>>.Error("Lista de Livros Vazia");
        }

        var model = loan.Select(l => LoanViewModel.FromEntity(l)).ToList();

        return ResultViewModel<List<LoanViewModel>>.Sucess(model);
    }
}