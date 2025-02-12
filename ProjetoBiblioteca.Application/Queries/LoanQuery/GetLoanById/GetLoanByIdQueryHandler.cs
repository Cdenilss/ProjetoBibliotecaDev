using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetLoanById;

public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery,ResultViewModel<LoanViewModel>>
{
    private readonly LibraryDbContext _context;

    public GetLoanByIdQueryHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var loans = await _context.Loans
            .Include(l => l.User)
            .Include(l=>l.Book)
            .FirstOrDefaultAsync(l => l.Id == request.Id);
       
        if (loans == null)
        {
            return ResultViewModel<LoanViewModel>.Error("Erro, emprestimo não encontrado"); 
        }

        var model = LoanViewModel.FromEntity(loans);


        return ResultViewModel<LoanViewModel>.Sucess(model);
    }
}