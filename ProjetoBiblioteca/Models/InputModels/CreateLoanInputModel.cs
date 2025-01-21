using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Models;

public class CreateLoanInputModel
{
    
    public int IdUser { get;  set; }
    public int IdBook { get;  set; }
    public DateTime LoanDate { get;  set; }
    public DateTime ReturnDate { get; set; }

    public Loan ToEntity()
        => new( IdUser, IdBook, LoanDate.Date, ReturnDate.Date);
}