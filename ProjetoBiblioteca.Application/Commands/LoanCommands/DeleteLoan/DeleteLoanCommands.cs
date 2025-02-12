using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services.Commands.LoanCommands.DeleteLoan;

public class DeleteLoanCommands : IRequest<ResultViewModel>
{
    public DeleteLoanCommands(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}