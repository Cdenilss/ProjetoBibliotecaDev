using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services;

public class LoanServices : ILoanService
{
    private readonly LibraryDbContext _context;

    public LoanServices(LibraryDbContext context)
    {
        _context = context;
    }

    public ResultViewModel<List<LoanViewModel>> GetAll()
    {
        var loan = _context.Loans
            .Where(b => !b.IsDeleted).ToList();

        if (loan == null)
        {
            return ResultViewModel<List<LoanViewModel>>.Error("Lista de Livros Vazia");
        }

        var model = loan.Select(l => LoanViewModel.FromEntity(l)).ToList();

        return ResultViewModel<List<LoanViewModel>>.Sucess(model);
    }

    public ResultViewModel<LoanViewModel> GetLoanById(int id)
    {
        var loans = _context.Loans
            .Include(l => l.User)
            .Include(l=>l.Book)
            .FirstOrDefault(l => l.Id == id);
        if (loans == null)
        {
            return ResultViewModel<LoanViewModel>.Error("Erro, emprestimo não encontrado"); 
        }

        var model = LoanViewModel.FromEntity(loans);


        return ResultViewModel<LoanViewModel>.Sucess(model);
    }

    public ResultViewModel<int> Insert(CreateLoanInputModel model)
    {
        var book = _context.Books.Find(model.IdBook);
        if (book == null)
        {
            return ResultViewModel<int>.Error("Book not found.");
        }

        if (book.Status != BookStatusEnum.Available)
        {
            return ResultViewModel<int>.Error("Livro ja emprestado");
        }
        

        var loan = model.ToEntity();
        _context.Add(loan);
        book.Loaned();
        _context.Update(book);
        _context.SaveChanges();
        return ResultViewModel<int>.Sucess(loan.Id);
    }

    public ResultViewModel Delete(int id)
    {
        var loan = _context.Loans.SingleOrDefault(l => l.Id == id);
        
        if (loan == null)
        {
            return ResultViewModel.Error("Emprestimo Não Encontrado");
        }

        var book = _context.Books.SingleOrDefault(b => b.Id == loan.IdBook);
        if (book !=null)
        {
            book.MakesAvailable();
            _context.SaveChanges();
        }
        loan.SetAsDeleted();
        _context.SaveChanges();
        return ResultViewModel.Sucess();
    }
    }
