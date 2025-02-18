using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Commands.LoanCommands.DeleteLoan;

public class DeleteLoanCommandsHandler : IRequestHandler<DeleteLoanCommands, ResultViewModel>
{
    private readonly ILoanRepository _repository;
    private readonly IBookRepository _bookRepository;

    public DeleteLoanCommandsHandler(ILoanRepository repository, IBookRepository bookRepository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
    }

    public async Task<ResultViewModel> Handle(DeleteLoanCommands request, CancellationToken cancellationToken)
    {
        var loan = await _repository.GetById(request.Id);
        
        if (loan == null)
        {
            return ResultViewModel.Error("Emprestimo Não Encontrado");
        }

        var book = await _bookRepository.GetById(loan.IdBook);
        if (book !=null)
        {
            book.MakesAvailable();
           await _bookRepository.Update(book);
        }
        loan.SetAsDeleted();
        await _repository.Update(loan);
        return ResultViewModel.Sucess();
    }
}