
using ProjetoBiblioteca.Core.Entities;


namespace ProjetoBiblioteca.Core.Entities;

public class Loan: BaseEntity
{
    public Loan( int idUser, int idBook, DateTime loanDate, DateTime returnDate) 
        : base()
    
    {
        
        IdUser = idUser;
        IdBook = idBook;
        LoanDate = loanDate;
        ReturnDate = returnDate;
    }

    public int Id { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
    public int IdBook { get; private set; }
    public Book Book { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    
}