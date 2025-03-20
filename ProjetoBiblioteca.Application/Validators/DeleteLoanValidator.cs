using FluentValidation;
using ProjetoBiblioteca.Application.Services.Commands.LoanCommands.DeleteLoan;

namespace ProjetoBiblioteca.Application.Validators;

public class DeleteLoanValidator : AbstractValidator<DeleteLoanCommands>
{
    public DeleteLoanValidator()
    {
        RuleFor(l => l.Id)
            .NotEmpty().WithMessage("Id do empréstimo é obrigatório.");
    }
    
}