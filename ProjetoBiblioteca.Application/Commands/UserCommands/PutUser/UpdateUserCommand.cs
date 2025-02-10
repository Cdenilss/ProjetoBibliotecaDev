using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services.Commands.UserCommands.PutUser;

public class UpdateUserCommand : IRequest<ResultViewModel>
{

    public int UserId { get; set; }
    public string Name { get;  set; }
    public string Email { get; set; }

      
      
}