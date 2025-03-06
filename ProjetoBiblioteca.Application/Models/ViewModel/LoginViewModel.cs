namespace ProjetoBiblioteca.Application.Models.ViewModel;

public class LoginViewModel
{
    public LoginViewModel(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
}