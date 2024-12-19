using System.Collections.Specialized;
using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models.ViewModel;

public class BookViewModel
{
    public BookViewModel(int id, string titulo, string autor, int anoDePublicacao, List<Loan> loans)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AnoDePublicacao = anoDePublicacao;
        TotalLoans = loans?.Count()??0;
    }

    public int  Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoDePublicacao { get; set; }
    public int TotalLoans { get; private set; }
}