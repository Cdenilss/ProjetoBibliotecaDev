using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models.ViewModel;

public class UserViewModel
{
    public UserViewModel(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; private set; }
    public string  Email { get; private set; }

    public User FromEntity(User user)
        => new(user.Name, user.Email);

}