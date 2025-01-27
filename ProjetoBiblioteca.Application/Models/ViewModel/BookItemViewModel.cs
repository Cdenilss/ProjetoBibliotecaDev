using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Application.Models.ViewModel;

public class BookItemViewModel
{
    public BookItemViewModel(int id, string title, string author, int yearOfPublication)
    {
        Id = id;
        Title = title;
        Author = author;
        YearOfPublication = yearOfPublication;
    }

    public int  Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int YearOfPublication { get;  private set; }

    public static BookItemViewModel FromEntity(Book book)
        => new(book.Id, book.Title, book.Author, book.YearOfPublication);

}