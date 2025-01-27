using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Application.Models.InputModels;
public class CreateUserInputModel
{
 
    public string Name { get;  set; }
    public string  Email { get;  set; }

    public User ToEntity()
        => new(Name, Email);
}