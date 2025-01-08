using ProjetoBiblioteca.Entites;
using ProjetoBiblioteca.Enums;

namespace ProjetoBiblioteca.Models;

public class CreateBooksInputModel
{
    public CreateBooksInputModel(int id, string title, string author, string isbn, DateTime yearOfPublication, int totalLoans)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        YearOfPublication = yearOfPublication;
        TotalLoans = totalLoans;
    }

    public int  Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    
    public DateTime YearOfPublication { get;  private set; }
    public int TotalLoans { get; private set; }

    public Book ToEntity()
        => new(Id, Title , Author,ISBN, YearOfPublication.Year, BookStatusEnum.Available);
    

}
