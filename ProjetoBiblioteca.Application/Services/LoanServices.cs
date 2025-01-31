using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services;

public class LoanServices : ILoanService
{
    private readonly LibraryDbContext _context;

    public LoanServices(LibraryDbContext context)
    {
        _context = context;
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
        var loan = model.ToEntity();
        _context.Add(loan);
        _context.SaveChanges();
        return ResultViewModel<int>.Sucess(loan.Id);
    }
}