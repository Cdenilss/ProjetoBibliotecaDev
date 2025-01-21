using ProjetoBiblioteca.Entites;
using ProjetoBiblioteca.Enums;

namespace ProjetoBiblioteca.Models;

public class CreateBooksInputModel
{
  

    public int  Id { get; set; }
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string ISBN { get;  set; }
    
    public DateTime YearOfPublication { get;   set; }
    

    public Book ToEntity()
        => new(Id, Title , Author,ISBN, YearOfPublication.Year, BookStatusEnum.Available);
    

}
