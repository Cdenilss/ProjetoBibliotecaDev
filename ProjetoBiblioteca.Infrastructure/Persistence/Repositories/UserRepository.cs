using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;

namespace ProjetoBiblioteca.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _context;
    private readonly IAuthService _auth;

    public UserRepository(LibraryDbContext context, IAuthService auth)
    {
        _context = context;
        _auth = auth;
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
            .ThenInclude(l => l.Book.Title)
            .SingleOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User?> GetById(int id)
        => await _context.Users.SingleOrDefaultAsync(l => l.Id == id);

    public async Task<int> Add(User user)
    {
        var hash = _auth.ComputeHash(user.Password);
        
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

    public Task<User> GetByEmail(string requestEmail)
    {
        return _context.Users.SingleOrDefaultAsync(u => u.Email == requestEmail);
    }

    public async Task<User?> AuthenticateUser(string email, string password)
    {
       var hashPassword = _auth.ComputeHash(password);
       return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == hashPassword);
    }
}