using FluentValidation;
using ProjetoBiblioteca.Application.Commands.UserCommands.InsertUser;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Validators;

public class CreateUserValidator : AbstractValidator<InsertUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(cmd => cmd.Email)
            .EmailAddress().WithMessage("E-mail inválido.")
            .MustAsync(async (email, ct) => await _userRepository.IsEmailUniqueAsync(email))
            .WithMessage("E-mail já cadastrado.");

        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.");
        RuleFor(u=>u.Password)
            .NotEmpty().WithMessage("Senha é obrigatória.")
            .MaximumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
        
    }
}