using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Commands.LoginCommand;

public class InsertLoginCommand : IRequest<ResultViewModel<string>>
{
    public string Email { get; set; } 
    public string Password { get; set; } 
    
    public InsertLoginCommand() { }

    
    public InsertLoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}