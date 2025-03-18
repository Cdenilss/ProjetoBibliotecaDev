using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly LibraryDbContext _context;

    public LoanRepository(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<List<Loan>> GetAll()
    {
        var loans = await _context.Loans.Where(l => !l.IsDeleted)
            .Include(l => l.User) 
            .Include(l => l.Book) 
            .ToListAsync();
        return loans;
    }

    public async Task<Loan?> GetDetailsById(int id)
    {
        var loans = await _context.Loans
            .Include(l => l.User)
            .Include(l=>l.Book)
            .FirstOrDefaultAsync(l => l.Id == id);
        return loans;
    }

    public async Task<Loan?> GetById(int id)
        => await _context.Loans.SingleOrDefaultAsync(l => l.Id == id);

    public async Task<int> Add(Loan loan)
    {
        await _context.Loans.AddAsync(loan);
        await _context.SaveChangesAsync();
        return loan.Id;
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Loans.AnyAsync(l => l.Id == id);
    }

    public async Task Update(Loan loan)
    {
        _context.Loans.Update(loan);
        
        await _context.SaveChangesAsync();
    }
}