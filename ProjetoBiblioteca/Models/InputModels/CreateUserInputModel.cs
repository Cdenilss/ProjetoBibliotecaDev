using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models;

public class CreateUserInputModel
{
 
    public string Name { get;  set; }
    public string  Email { get;  set; }

    public User ToEntity()
        => new(Name, Email);
}