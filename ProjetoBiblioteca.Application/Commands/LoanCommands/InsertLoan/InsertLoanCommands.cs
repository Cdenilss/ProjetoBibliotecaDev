using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;


namespace ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanCommands : IRequest<ResultViewModel<int>>
{
    public int IdUser { get; set; }
    public int IdBook { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public Loan ToEntity()
        => new(IdUser, IdBook, LoanDate.Date, ReturnDate.Date);
}
