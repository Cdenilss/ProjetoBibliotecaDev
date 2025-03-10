using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.PutPasswordRecovery;

public class PasswordRecoveryValidateCommand : IRequest<ResultViewModel>
{
    public PasswordRecoveryValidateCommand(string email, string code)
    {
        Email = email;
        Code = code;
    }

    public string Email { get; set; }
    public string Code { get; set; }
}