using ProjetoBiblioteca.Enums;

namespace ProjetoBiblioteca.Entites;

public class Book: BaseEntity
{
    protected Book(){}
    public Book(int id, string titulo, string autor, string isbn, int anoDePublicacao, BookStatusEnum status)
    :base()
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        AnoDePublicacao = anoDePublicacao;
        Status = status;
    }

    public int  Id { get; private set; }
    
    public string Titulo { get; private set; }
    
    public string Autor { get; private set; }
    
    public string ISBN { get; private set; }
   
    public int AnoDePublicacao { get; private set; }
    
    public BookStatusEnum Status { get; private set; }
    
    public List<Loan> Loans { get; private set; }

    public bool Disponivel() 
        => Status == BookStatusEnum.Disponivel || Status == BookStatusEnum.Lido;
    
    

    
    
}