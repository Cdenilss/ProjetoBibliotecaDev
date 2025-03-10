using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.PutPasswordRecovery;

public class PasswordRecoveryRequestCommand :   IRequest<ResultViewModel>
{
    public PasswordRecoveryRequestCommand(string email)
    {
        Email = email;
    }

    public string Email { get; set; }
}