using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetLoanById;

public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery,ResultViewModel<LoanViewModel>>
{
    private readonly ILoanRepository _repository;

    public GetLoanByIdQueryHandler(ILoanRepository repository)
    {
        _repository=repository;
    }

    public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var loans = await _repository.GetDetailsById(request.Id);
        if (loans == null)
        {
            return ResultViewModel<LoanViewModel>.Error("Erro, emprestimo não encontrado"); 
        }
        var model = LoanViewModel.FromEntity(loans);
        return ResultViewModel<LoanViewModel>.Sucess(model);
    }
}