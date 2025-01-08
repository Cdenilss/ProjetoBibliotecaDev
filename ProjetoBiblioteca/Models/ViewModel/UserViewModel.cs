using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models.ViewModel;

public class UserViewModel
{
   

    public UserViewModel(string name, string email, int id)
    {
        Name = name;
        Email = email;
        Id = id;
        
    }

    public string Name { get; private set; }
    public string  Email { get; private set; }
    public int Id { get; set; }
    
    public List<string>Loans { get; private set; }

    public static UserViewModel FromEntity(User user)
        => new(user.Name, user.Email, user.Id);


}