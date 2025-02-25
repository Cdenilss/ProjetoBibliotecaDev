using FluentValidation;
using ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;

namespace ProjetoBiblioteca.Application.Validators;

public class CreateUserValidator : AbstractValidator<InsertUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
                .WithMessage("Email Invalido");
        RuleFor(u => u.Name).NotEmpty().WithMessage("Nome não pode ser nulo");
    }
}