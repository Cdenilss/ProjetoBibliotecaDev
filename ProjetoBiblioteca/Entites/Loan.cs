namespace ProjetoBiblioteca.Entites;

public class Loan: BaseEntity
{
    public Loan(int id, int idUser, int idBook, DateTime dataEmprestimo, DateTime dataFinal) 
        : base()
    
    {
        Id = id;
        IdUser = idUser;
        IdBook = idBook;
        DataEmprestimo = dataEmprestimo;
        DataFinal = dataFinal;
    }

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public int IdBook { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataFinal { get; private set; }
   
    public User User { get; private set; }
    public Book Book { get; private set; }
    
    
}