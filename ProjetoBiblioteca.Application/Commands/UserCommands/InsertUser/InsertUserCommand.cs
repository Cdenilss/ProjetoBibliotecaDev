using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Password { get; set; } 
    public string Role { get; set; } 

   
    public InsertUserCommand() { }
    
    public InsertUserCommand(string name, string email, string password, string role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
    
    public User ToEntity(string hashedPassword) 
        => new(Name, Email, hashedPassword, Role);
}