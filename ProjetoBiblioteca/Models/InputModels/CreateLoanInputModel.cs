namespace ProjetoBiblioteca.Models;

public class CreateLoanInputModel
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdBook { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataFinal { get; set; }
}