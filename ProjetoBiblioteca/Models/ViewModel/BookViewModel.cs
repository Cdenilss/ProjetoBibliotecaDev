using System.Collections.Specialized;
using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models.ViewModel;

public class BookViewModel
{
    public BookViewModel(int id, string title, string author, int yearOfPublication, List<Loan> loans)
    {
        Id = id;
        Title = title;
        Author = author;
        YearOfPublication = yearOfPublication;
        TotalLoans = loans?.Count()??0;
    }

    public int  Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int YearOfPublication { get;  private set; }
    public int TotalLoans { get; private set; }

    public static BookViewModel FromEntity(Book book)
        => new(book.Id, book.Title, book.Author, book.YearOfPublication,new List<Loan>());
}