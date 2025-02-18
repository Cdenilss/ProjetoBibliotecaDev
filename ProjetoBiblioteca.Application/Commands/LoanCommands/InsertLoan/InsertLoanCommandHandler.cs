using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;

public class InsertLoanCommandHandler : IRequestHandler<InsertLoanCommands,ResultViewModel<int>>
{
    private readonly IBookRepository _bookRepository;

    private readonly ILoanRepository _repository;

    public InsertLoanCommandHandler(ILoanRepository repository,IBookRepository bookRepository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
    }
    public async Task<ResultViewModel<int>> Handle(InsertLoanCommands request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetById(request.IdBook);
        if (book == null)
        {
            return ResultViewModel<int>.Error("Book not found.");
        }
        if (book.Status != BookStatusEnum.Available)
        {
            return ResultViewModel<int>.Error("Livro ja emprestado");
        }
        book.Loaned(); 
        await _bookRepository.Update(book);
        var loans = request.ToEntity();
        await _repository.Add(loans);
        return ResultViewModel<int>.Sucess(loans.Id);
    }
}