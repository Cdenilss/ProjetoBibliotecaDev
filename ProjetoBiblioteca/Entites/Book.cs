using ProjetoBiblioteca.Enums;

namespace ProjetoBiblioteca.Entites;

public class Book: BaseEntity
{
    protected Book(){}
    public Book(int id, string title, string author, string isbn, int yearOfPublication, BookStatusEnum status)
    :base()
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        YearOfPublication = yearOfPublication;
        Status = status;
    }

    public int  Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Author { get; private set; }
    
    public string ISBN { get; private set; }
   
    public int YearOfPublication { get; private set; }
    
    public BookStatusEnum Status { get; private set; }
    
    public List<Loan> Loans { get; private set; }

    public bool Disponivel()
        => Status == BookStatusEnum.Available;





}