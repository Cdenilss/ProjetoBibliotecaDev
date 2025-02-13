using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;

namespace ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;

public class InsertBookCommand:  IRequest<ResultViewModel<int>>
{
    
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string ISBN { get;  set; }
    
    public int YearOfPublication { get;   set; }
    

    public Book ToEntity()
        => new( Title , Author,ISBN, YearOfPublication, BookStatusEnum.Available);

}