using FluentValidation;
using ProjetoBiblioteca.Application.Commands.UserCommands.DeleteUser;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Validators;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(u => u.Id)
            .NotEmpty().WithMessage("Id do usuário é obrigatório.")
            .MustAsync(UserExists).WithMessage("Usuário não encontrado.")
            .DependentRules(() =>
            {
                RuleFor(u => u.Id)
                    .MustAsync(NoActiveLoans).WithMessage("Usuário possui empréstimos ativos.");
            });
        
    }
    private async Task<bool> UserExists(int id, CancellationToken ct)
    {
        return await _userRepository.Exists(id);
    }
    
    private async Task<bool>NoActiveLoans(int id, CancellationToken ct)
    {
        return !await _userRepository.ExistLoans(id);
    }
}