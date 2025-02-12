using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public InsertUserCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get;  set; }
    public string  Email { get;  set; }

    public User ToEntity()
        => new(Name, Email);
}