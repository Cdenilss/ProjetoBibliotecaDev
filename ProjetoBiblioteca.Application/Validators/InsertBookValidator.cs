using FluentValidation;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Application.Validators;

public class InsertBookValidator : AbstractValidator<InsertBookCommand>
{
    public InsertBookValidator()
    {
        RuleFor(b=>b.Title)
            .NotEmpty()
                .WithMessage("Titulo do livro não pode ser vazio")
            .MaximumLength(50)
            .WithMessage("Tamano de maximo de de caracteres é 50");

        RuleFor(b => b.YearOfPublication)
            .NotEmpty() 
                .WithMessage("Titulo do livro não pode ser vazio").GreaterThan(DateTime.Now.Year);
        
        RuleFor(b => b.ISBN)
            .NotEmpty().WithMessage("O ISBN é obrigatório.")
            .Length(10, 13).WithMessage("ISBN inválido.");
    }
}