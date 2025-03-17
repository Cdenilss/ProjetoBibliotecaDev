using MediatR;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;

public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand,ResultViewModel<int>>
{
    private readonly IBookRepository _repository;

    public InsertBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {

            var book = request.ToEntity();
            
            var id= await _repository.Add(book);
          return ResultViewModel<int>.Success(id);
          
    }
}