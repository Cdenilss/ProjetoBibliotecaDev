using System.Collections.Specialized;
using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models.ViewModel;

public class BookViewModel
{
    public BookViewModel(int id, string title, string author, int yearOfPublication,int totalLoans)
    {
        Id = id;
        Title = title;
        Author = author;
        YearOfPublication = yearOfPublication;
        TotalLoans = totalLoans;
    }

    public int  Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int YearOfPublication { get;  private set; }
    public int TotalLoans { get; private set; }

    public static BookViewModel FromEntity(Book book)
    {
        var loansActive = book.Loans?.Count(loan => !loan.IsDeleted)?? 0;
        return new(book.Id, book.Title, book.Author, book.YearOfPublication, loansActive );
    }
}