using System.Data;
using System.Text.Json.Serialization;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Infrastructure.Serialization;
using ProjetoBiblioteca.Infrastructure.Serialization.ProjetoBiblioteca.Infrastructure.Serialization;

namespace ProjetoBiblioteca.Application.Models.InputModels;

public class CreateLoanInputModel
{
    public int IdUser { get; set; }
    public int IdBook { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Loan ToEntity()
        => new(IdUser, IdBook, LoanDate.Date, ReturnDate.Date);
}