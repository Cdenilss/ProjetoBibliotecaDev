using FluentValidation;
using ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Validators;

public class InsertLoanValidator : AbstractValidator<InsertLoanCommands>
{
    private readonly IBookRepository _bookRepository;

    public InsertLoanValidator(IBookRepository bookRepository)
    {
        RuleFor(cmd => cmd.LoanDate)
            .GreaterThanOrEqualTo(DateTime.Now.Date)
            .WithMessage("A data de empréstimo deve ser anterior à data de devolução.");
        RuleFor(cmd => cmd.IdBook)
            .MustAsync(async (idBook, ct) =>
            {
                var book = await bookRepository.GetById(idBook);
                return book is not null && book.Status == BookStatusEnum.Available;
            })
            .WithMessage("Livro já emprestado.");
        
        RuleFor(cmd=>cmd.IdBook)
            .MustAsync(BookExists)
            .WithMessage("Livro não encontrado.");
    }

    private async Task<bool> BookExists(int bookId, CancellationToken cancellationToken)
    {
        return await _bookRepository.Exists(bookId);
    }
}
    
    
  