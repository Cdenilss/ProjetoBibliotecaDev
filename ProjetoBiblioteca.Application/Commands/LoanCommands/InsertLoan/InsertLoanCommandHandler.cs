using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanCommandHandler : IRequestHandler<InsertLoanCommands,ResultViewModel<int>>
{
    private readonly LibraryDbContext _context;

    public InsertLoanCommandHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<int>> Handle(InsertLoanCommands request, CancellationToken cancellationToken)
    {
        var book =  _context.Books.Find(request.IdBook);
        if (book == null)
        {
            return ResultViewModel<int>.Error("Book not found.");
        }

        if (book.Status != BookStatusEnum.Available)
        {
            return ResultViewModel<int>.Error("Livro ja emprestado");
        }
        

        var loan =  request.ToEntity();
        await _context.AddAsync(loan);
        book.Loaned(); 
        _context.Update(book);
        await _context.SaveChangesAsync();
        return ResultViewModel<int>.Sucess(loan.Id);
    }
}