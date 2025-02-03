using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;

namespace ProjetoBiblioteca.Application.Models.InputModels;

public class CreateBooksInputModel
{
  
    
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string ISBN { get;  set; }
    
    public DateTime YearOfPublication { get;   set; }
    

    public Book ToEntity()
        => new( Title , Author,ISBN, YearOfPublication.Year, BookStatusEnum.Available);
    

}
