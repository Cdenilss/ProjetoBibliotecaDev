using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.DeleteUser;

public class DeleteUserCommand : IRequest<ResultViewModel>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    
}