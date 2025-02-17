using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanCommandHandler : IRequestHandler<InsertLoanCommands,ResultViewModel<int>>
{
    private readonly LibraryDbContext _context;

    private readonly ILoanRepository _repository;

    public InsertLoanCommandHandler(ILoanRepository repository)
    {
        _repository = repository;
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
        book.Loaned(); 
        _context.Update(book);
        var loans = request.ToEntity();
        await _repository.Add(loans);
        await _context.SaveChangesAsync();
        return ResultViewModel<int>.Sucess(loans.Id);
    }
}