using MediatR;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommand : IRequest<ResultViewModel<int>>
{
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Password { get; set; } 
    public RoleUserEnum Role { get; set; } 

   
    public InsertUserCommand() { }
    
    public InsertUserCommand(string name, string email, string password, RoleUserEnum role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
    
    public User ToEntity(string hashedPassword) 
        => new(Name, Email, hashedPassword, Role);
}