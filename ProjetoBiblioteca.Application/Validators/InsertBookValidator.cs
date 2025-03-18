using FluentValidation;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Application.Validators;

public class InsertBookValidator : AbstractValidator<InsertBookCommand>
{
    private readonly IBookRepository _bookRepository;
    public InsertBookValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        RuleFor(b=>b.Title)
            .NotEmpty()
                .WithMessage("Titulo do livro não pode ser vazio")
            .MaximumLength(50)
            .WithMessage("Tamanho de maximo de de caracteres é 50");
       RuleFor(b=>b.Title)
           .MustAsync(IsTitleExists).WithMessage("Livro já cadastrado");
        
        RuleFor(b=>b.Author)
            .NotEmpty()
                .WithMessage("Autor do livro não pode ser vazio")
            .MaximumLength(50)
            .WithMessage("Tamanho de maximo de de caracteres é 50");

        RuleFor(b => b.YearOfPublication)
            .LessThanOrEqualTo(DateTime.Now.Year)
            .WithMessage($"O ano de publicação não pode ser maior que {DateTime.Now.Year}.");

        RuleFor(b => b.ISBN)
            .NotEmpty().WithMessage("O ISBN é obrigatório.");
        
    }
    
    private async Task<bool> IsTitleExists(string title, CancellationToken ct)
    {
        return !await _bookRepository.ExistsByTitle(title);
        
    }
 
}