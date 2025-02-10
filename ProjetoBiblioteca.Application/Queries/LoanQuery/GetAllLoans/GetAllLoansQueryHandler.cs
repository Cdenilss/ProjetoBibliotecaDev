using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Queries.LoanQuery.GetAllLoans;

public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery,ResultViewModel<List<LoanViewModel>>>
{
    private readonly LibraryDbContext _context;

    public GetAllLoansQueryHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public  async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
        var loan = await _context.Loans.Where(l => !l.IsDeleted)
            .Include(l => l.User) // 
            .Include(l => l.Book) // 
            .ToListAsync();

        if (loan==null) 
        {
            return ResultViewModel<List<LoanViewModel>>.Error("Lista de Livros Vazia");
        }

        var model = loan.Select(l => LoanViewModel.FromEntity(l)).ToList();

        return ResultViewModel<List<LoanViewModel>>.Sucess(model);
    }
}