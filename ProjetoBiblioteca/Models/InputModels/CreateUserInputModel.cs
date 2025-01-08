using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models;

public class CreateUserInputModel
{
    public CreateUserInputModel(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public int  Id { get; set; }
    public string Name { get; set; }
    public string  Email { get; set; }

    public User ToEntity()
        => new(Name, Email, Id);
}