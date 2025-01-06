using ProjetoBiblioteca.Entites;
using ProjetoBiblioteca.Enums;

namespace ProjetoBiblioteca.Models;

public class CreateBooksInputModel
{
    public int  Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public DateTime AnoDePublicacao { get; set; }

    public Book ToEntity()
        => new(Id, Titulo, Autor, ISBN, AnoDePublicacao.Year, BookStatusEnum.Disponivel);

}
