using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;

namespace ProjetoBiblioteca.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<List<Book>> GetAll()
    {
        var books = await _context.Books
            .Where(b => !b.IsDeleted)
            .Include(b=>b.Loans)
            .ToListAsync();

        return books;

    }

    public async Task<Book?> GetDetailsById(int id)
    {
        var books = await _context.Books
            .Include(b => b.Loans)
            .SingleOrDefaultAsync(b => b.Id == id);
        return books;
    }

    public async Task<Book?> GetById(int id)
    {
        return await _context.Books
            .Where(b => !b.IsDeleted) 
            .SingleOrDefaultAsync(b => b.Id == id);

    }

    public async Task<int> Add(Book book)
    {
        await _context.Books.AddAsync(book);
        await  _context.SaveChangesAsync();
        return book.Id;
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Books.AnyAsync(b => b.Id == id);
    }
    public async Task Update(Book book)
    {
        _context.Books.Update(book);
        
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByTitle(string title)
    {
        return await _context.Books.AnyAsync(b=>b.Title == title);
    }
}