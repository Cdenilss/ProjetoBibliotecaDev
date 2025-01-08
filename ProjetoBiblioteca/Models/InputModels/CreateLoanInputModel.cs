namespace ProjetoBiblioteca.Models;

public class CreateLoanInputModel
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdBook { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
}