using FluentValidation;
using ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Validators;

public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;
    
    public DeleteBookValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        
        RuleFor(b => b.Id)
            .NotEmpty().WithMessage("Id do livro é obrigatório.")
            .MustAsync(BookExists).WithMessage("Livro não encontrado.")
            .DependentRules(() =>
            {
                RuleFor(b => b.Id)
                    .MustAsync(NoActiveLoans).WithMessage("Livro possui empréstimos ativos.");
            });
    }
    
    public async Task<bool> BookExists(int id, CancellationToken ct)
    {
        return await _bookRepository.Exists(id);
    }
    
    public async Task<bool>NoActiveLoans(int id, CancellationToken ct)
    {
        return !await _bookRepository.LoansActive(id);
        
    }
}