using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _context;

    public UserRepository(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetAll()
    {
       
        var user = await _context.Users
            .Where(u => !u.IsDeleted).ToListAsync();
        return user;

    }

    public async Task<User?> GetDetailsById(int id)
    {
        var user = await _context.Users
            .Include(u => u.LoansList)
            .ThenInclude(l => l.Book)
            .SingleOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User?> GetById(int id)
        => await _context.Users.SingleOrDefaultAsync(l => l.Id == id);

    public async Task<int> Add(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }

    public async Task Update(User user)
    {
       
       _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}