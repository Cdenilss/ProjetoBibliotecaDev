using ProjetoBiblioteca.Core.Entities;


namespace ProjetoBiblioteca.Application.Models.ViewModel;

public class UserViewModel
{


    public UserViewModel(string name, string email, int id, List<string>? loans)
    {
        Name = name;
        Email = email;
        Id = id;
        LoansBookTitle = loans;

    }


    public string Name { get; private set; }
    public string Email { get; private set; }
    public int Id { get; private  set; }

    public List<string>? LoansBookTitle { get; private set; }

    public static UserViewModel FromEntity(User user)
    {
        var loanedBooks = user.LoansList?
            .Where(l=>l.Book!= null)
            .Select(loan => loan.Book.Title) 
            .ToList();
        return new(user.Name, user.Email, user.Id, loanedBooks);
        
    }
}