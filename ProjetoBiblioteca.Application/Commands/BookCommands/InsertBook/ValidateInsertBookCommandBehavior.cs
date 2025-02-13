using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;

public class ValidateInsertBookCommandBehavior : IPipelineBehavior<InsertBookCommand, ResultViewModel<int>>
{
    private readonly LibraryDbContext _context;

    public ValidateInsertBookCommandBehavior(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        if (request.YearOfPublication > DateTime.Now.Year)
        {
            return ResultViewModel<int>.Error("Ano de publicação inválido. O ano não pode ser no futuro.");
        }
        
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return ResultViewModel<int>.Error("O título do livro não pode ser vazio.");
        }
        
        var titleExists = await _context.Books.AnyAsync(b => b.Title == request.Title, cancellationToken);
        if (titleExists)
        {
            return ResultViewModel<int>.Error("Já existe um livro com esse título cadastrado.");
        }

        return await next();
    }
}