using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Infrastructure.Serialization;
using System.Text.Json.Serialization;
using ProjetoBiblioteca.Infrastructure.Serialization.ProjetoBiblioteca.Infrastructure.Serialization;


namespace ProjetoBiblioteca.Application.Models.ViewModel;

public class LoanViewModel
{
    public LoanViewModel(int id, int idUser, string userName, int idBook, string bookTitle, DateTime loanDate, DateTime returnDate)
    {
        Id = id;
        IdUser = idUser;
        UserName = userName;
        IdBook = idBook;
        BookTitle = bookTitle;
        LoanDate = loanDate;
        ReturnDate = returnDate;
    }
    

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public string UserName { get; private set; }
    public int IdBook { get; private set; }
    public string BookTitle { get; private set; }
    public DateTime LoanDate { get; private set; }
    
    public DateTime ReturnDate { get; private set; }

    public static LoanViewModel FromEntity(Loan loan)
        => new(loan.Id, loan.IdUser, loan.User.Name, loan.IdBook, loan.Book.Title, loan.LoanDate, loan.ReturnDate);
}