using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Commands.LoanCommands.DeleteLoan;

public class DeleteLoanCommandsHandler : IRequestHandler<DeleteLoanCommands, ResultViewModel>
{
    private readonly LibraryDbContext _context;

    public DeleteLoanCommandsHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel> Handle(DeleteLoanCommands request, CancellationToken cancellationToken)
    {
        var loan =  await _context.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);
        
        if (loan == null)
        {
            return ResultViewModel.Error("Emprestimo Não Encontrado");
        }

        var book =  await _context.Books.SingleOrDefaultAsync(b => b.Id == loan.IdBook);
        if (book !=null)
        {
            book.MakesAvailable();
           await _context.SaveChangesAsync();
        }
        loan.SetAsDeleted();
        await _context.SaveChangesAsync();
        return ResultViewModel.Sucess();
    }
}