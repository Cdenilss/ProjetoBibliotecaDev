using FluentValidation;
using ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Validators;

public class InsertLoanValidator : AbstractValidator<InsertLoanCommands>
{
    public InsertLoanValidator(IBookRepository bookRepository)
    {
        RuleFor(cmd => cmd.LoanDate)
            .Must((cmd, loanDate) => loanDate <= cmd.ReturnDate)
            .WithMessage("A data de empréstimo deve ser anterior à data de devolução.");
    }
    }
