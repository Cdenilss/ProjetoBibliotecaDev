using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.PutPasswordRecovery;

public class PasswordRecoveryChangeCommand : IRequest<ResultViewModel>
{
    public PasswordRecoveryChangeCommand(string email, string code, string newPassword)
    {
        Email = email;
        Code = code;
        NewPassword = newPassword;
    }

    public string Email { get; set; }
    public string Code { get; set; }
    public string NewPassword { get; set; }
}